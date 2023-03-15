using admissionapi.services.Data;
using admissionapi.services.Entities;
using admissionapi.services.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace admissionapi.services.Repository;

public class EmgRepository : GenericRepository<EmergencyInfo>, IEmgRepository
{
    public EmgRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

     public override async Task<IEnumerable<EmergencyInfo>> GetAllAsync(PaginationFilter? paginationFilter = null)
        {
            try
            {
                return await dbset.Where(x => x.IsDeleted == false)
                    .OrderBy(x => x.Relation)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method has generated an error", typeof(GardianRepository));
                return Enumerable.Empty<EmergencyInfo>();
            }
        }
        public override async Task<EmergencyInfo?> UpdateAsync(EmergencyInfo entity, Guid Key)
        {
            if (entity is null)
                return null;

            var existing = await dbset.FindAsync(Key);

            if (existing is not null)
            {
                existing.Relation = entity.Relation;
                existing.Email = entity.Email;
                existing.Phone = entity.Phone;
                
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