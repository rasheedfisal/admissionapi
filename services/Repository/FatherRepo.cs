using admissionapi.services.Data;
using admissionapi.services.Entities;
using admissionapi.services.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace admissionapi.services.Repository;

public class FatherRepository : GenericRepository<FatherInfo>, IFatherRepository
{
    public FatherRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

     public override async Task<IEnumerable<FatherInfo>> GetAllAsync(PaginationFilter? paginationFilter = null)
        {
            try
            {
                return await dbset.Where(x => x.IsDeleted == false)
                    .OrderBy(x => x.FirstName)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method has generated an error", typeof(GardianRepository));
                return Enumerable.Empty<FatherInfo>();
            }
        }
        public override async Task<FatherInfo?> UpdateAsync(FatherInfo entity, Guid Key)
        {
            if (entity is null)
                return null;

            var existing = await dbset.FindAsync(Key);

            if (existing is not null)
            {
                existing.FirstName = entity.FirstName;
                existing.SecondName = entity.SecondName;
                existing.MiddleName = entity.MiddleName;
                existing.Surname = entity.Surname;
                existing.Email = entity.Email;
                existing.PhoneOne = entity.PhoneOne;
                existing.PhoneTwo = entity.PhoneTwo;
                existing.Address = entity.Address;
                
                existing.UpdateDate = DateTime.Now;
            }

            return entity;
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
}