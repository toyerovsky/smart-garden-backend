using System;

namespace PSK.SmartGarden.Data.Input
{
    public class GetMeasurementListInput
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public Sort? SortType { get; set; }

        public SortDirection SortDirection { get; set; }

        public enum Sort
        {
            Date,
            AirHumidity,
            AirTemperature,
            SoilMoisture
        }
    }
}