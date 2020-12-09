using System;
using System.Collections.Generic;

namespace PSK.SmartGarden
{
    public class GetMeasurementListOutputDto
    {
        public IList<ListItemDto> Data { get; set; }

        public class ListItemDto
        {
            public DateTime MeasurementDate { get; set; }
            public float AirHumidity { get; set; }
            public float AirTemperature { get; set; }
            public float SoilMoisture { get; set; }
        }
    }
}