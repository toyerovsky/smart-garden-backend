namespace PSK.SmartGarden.Data
{
    public interface IGardenDatabaseSettings
    {
        public string MeasurementsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}