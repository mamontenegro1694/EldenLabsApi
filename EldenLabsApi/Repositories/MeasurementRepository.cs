using EldenLabsApi.Database;
using EldenLabsApi.Database.Entities;
using EldenLabsApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EldenLabsApi.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly AppDbContext _dbContext;

        public MeasurementRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Measurement>> GetAll(string? startDate = null, string? endDate = null)
        {
            IQueryable<Measurement> query = _dbContext.Measurements;

            if (startDate != null && endDate != null)
            {
                DateTime startDateDT = DateTime.Parse(startDate).Date;
                DateTime endDateDT = DateTime.Parse(endDate).Date;

                query = query.Where(m => m.EventProcessedUtcTime.Date >= startDateDT && m.EventProcessedUtcTime.Date<= endDateDT);
            }

            return await query.ToListAsync();
        }

        public async Task CreateFromList(List<Measurement> measurementsToCreate)
        {
            await _dbContext.Measurements.AddRangeAsync(measurementsToCreate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
