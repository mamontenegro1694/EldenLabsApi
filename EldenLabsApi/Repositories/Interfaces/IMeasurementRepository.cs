using EldenLabsApi.Database.Entities;

namespace EldenLabsApi.Repositories.Interfaces
{
    public interface IMeasurementRepository
    {
        public Task<IEnumerable<Measurement>> GetAll(string? startDate = null, string? endDate = null);

        public Task CreateFromList(List<Measurement> measurementsToCreate);
    }
}
