using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PSK.SmartGarden.Data
{
    public class MeasurementEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public DateTime Date { get; set; }
        public float AirHumidity { get; set; }
        public float AirTemperature { get; set; }
        public float SoilMoisture { get; set; }
    }
}