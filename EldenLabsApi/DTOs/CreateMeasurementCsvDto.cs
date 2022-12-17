using CsvHelper.Configuration.Attributes;

namespace EldenLabsApi.DTOs
{
    [Delimiter(",")]
    //[CultureInfo("")]
    public class CreateMeasurementCsvDto
    {
        [Name("ConnectionDeviceId")]
        public string ConnectionDeviceId { get; set; }
        [Name("EventProcessedUtcTime")]
        public DateTime EventProcessedUtcTime { get; set; }
        [Name("HEFESTO_ID")]
        public string HefestoId { get; set; }
        [Name("timestamp")]
        public DateTime Timestamp { get; set; }
        [Name("var-name")]
        public string VarName { get; set; }
        [Name("value")]
        public int Value { get; set; }
        [Name("plugin")]
        public string Plugin { get; set; }
        [Name("request")]
        public string Request { get; set; }
        [Name("var_name_1")]
        public string VarName1 { get; set; }
        [Name("device")]
        public int Device { get; set; }
    }
}
