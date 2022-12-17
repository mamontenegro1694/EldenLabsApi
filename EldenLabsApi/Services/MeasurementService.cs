using CsvHelper;
using EldenLabsApi.Database.Entities;
using EldenLabsApi.DTOs;
using EldenLabsApi.Repositories.Interfaces;
using EldenLabsApi.Services.Interfaces;
using System.Globalization;

namespace EldenLabsApi.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _measurementRepository;

        public MeasurementService(IMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }

        public Task<IEnumerable<Measurement>> GetAll(string? startDate = null, string? endDate = null)
        {
            return _measurementRepository.GetAll(startDate, endDate);
        }

        public async Task CreateFromCsv(IFormFile csvFile)
        {
            using (var fileStream = csvFile.OpenReadStream())
            using (var reader = new StreamReader(fileStream))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                IEnumerable<CreateMeasurementCsvDto> records = csvReader.GetRecords<CreateMeasurementCsvDto>();

                List<Measurement> measurementsEntities = records.Select(record =>
                {
                    return new Measurement()
                    {
                        ConnectionDeviceId = record.ConnectionDeviceId,
                        EventProcessedUtcTime = record.EventProcessedUtcTime,
                        HefestoId = record.HefestoId,
                        Timestamp = record.Timestamp,
                        VarName = record.VarName,
                        Value = record.Value,
                        Plugin = record.Plugin,
                        Request = record.Request,
                        VarName1 = record.VarName1,
                        Device = record.Device
                    };
                }).ToList();

                await _measurementRepository.CreateFromList(measurementsEntities);
            }
        }
    }
}
