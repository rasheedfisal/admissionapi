using admissionapi.services.Data;
using admissionapi.services.Entities;
using admissionapi.services.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace admissionapi.services.Repository;

public class AdmRepository : GenericRepository<Admission>, IAdmRepository
{
    public AdmRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

     public override async Task<IEnumerable<Admission>> GetAllAsync(PaginationFilter? paginationFilter = null)
        {
            try
            {
                return await dbset.Where(x => x.IsDeleted == false)
                    .OrderBy(x => x.AddedDate)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method has generated an error", typeof(GardianRepository));
                return Enumerable.Empty<Admission>();
            }
        }
        public override async Task<bool> DeleteAsync(Guid Key)
        {
            // soft delete
            var existing = await dbset.SingleOrDefaultAsync(x => x.Id == Key);
            if (existing is null)
            {
                return false;
            }

            existing.IsDeleted = true;
            return true;
        }

    public async Task<Admission?> GetAdmissionByPhone(string key)
    {
        try
        {
            var grd = await _context.GardianInfos.SingleOrDefaultAsync(x => x.PhoneOne== key);
            if (grd == null) return null;

            return await dbset.Where(x => x.Id == grd.AdmId)
                    .Include(x => x.Gardian)
                    .Include(x => x.Emergency)
                    .Include(x => x.Martial)
                    .Include(x => x.Father)
                    .Include(x => x.Mother)
                    .Include(x => x.Students)
                    .OrderByDescending(x => x.AddedDate)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}