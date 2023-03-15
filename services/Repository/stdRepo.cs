using admissionapi.services.Data;
using admissionapi.services.Entities;
using admissionapi.services.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace admissionapi.services.Repository;

public class StdRepository : GenericRepository<StudentInfo>, IStdRepository
{
    public StdRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

     public override async Task<IEnumerable<StudentInfo>> GetAllAsync(PaginationFilter? paginationFilter = null)
        {
            try
            {
                return await dbset.Where(x => x.IsDeleted == false)
                    .OrderBy(x => x.Name)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method has generated an error", typeof(GardianRepository));
                return Enumerable.Empty<StudentInfo>();
            }
        }
        public override async Task<StudentInfo?> UpdateAsync(StudentInfo entity, Guid Key)
        {
            if (entity is null)
                return null;

            var existing = await dbset.FindAsync(Key);

            if (existing is not null)
            {
                existing.Name = entity.Name;
                existing.BirthDate = entity.BirthDate;
                existing.ClassName = entity.ClassName;
                existing.Gender = entity.Gender;
                if (entity.ImagePath is not null)
                {
                    existing.ImagePath = entity.ImagePath;
                }
                if (entity.BirthCrt is not null)
                {
                    existing.BirthCrt = entity.BirthCrt;
                }
                if (entity.PassportCrt is not null)
                {
                    existing.PassportCrt = entity.PassportCrt;
                }
                if (entity.DocOne is not null)
                {
                    existing.DocOne = entity.DocOne;
                }
                if (entity.DocTwo is not null)
                {
                     existing.DocTwo = entity.DocTwo;
                }
                
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