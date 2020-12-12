using System;
using PSK.SmartGarden.Dto.Base;

namespace PSK.SmartGarden.Dto.Measurement
{
    public class GetMeasurementListInputDto : BasePageableSortableListInputDto
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public SortDto? SortType { get; set; }

        public enum SortDto
        {
            Date,
            AirHumidity,
            AirTemperature,
            SoilMoisture
        }
    }
}