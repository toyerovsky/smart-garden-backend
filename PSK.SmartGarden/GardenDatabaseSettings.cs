using PSK.SmartGarden.Data;

namespace PSK.SmartGarden
{
    class GardenDatabaseSettings : IGardenDatabaseSettings
    {
        public string MeasurementsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}