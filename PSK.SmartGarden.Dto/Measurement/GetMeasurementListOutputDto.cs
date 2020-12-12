using System;
using System.Collections.Generic;
using PSK.SmartGarden.Dto.Base;

namespace PSK.SmartGarden.Dto.Measurement
{
    public class GetMeasurementListOutputDto : BasePageableListOutputDto
    {
        public IList<ListItemDto> Data { get; set; }

        public class ListItemDto
        {
            public DateTime Date { get; set; }
            public float AirHumidity { get; set; }
            public float AirTemperature { get; set; }
            public float SoilMoisture { get; set; }
        }
    }
}