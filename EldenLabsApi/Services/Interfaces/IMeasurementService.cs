using EldenLabsApi.Database.Entities;

namespace EldenLabsApi.Services.Interfaces
{
    public interface IMeasurementService
    {
        public Task<IEnumerable<Measurement>> GetAll(string? startDate = null, string? endDate = null);

        public Task CreateFromCsv(IFormFile csvFile);
    }
}
