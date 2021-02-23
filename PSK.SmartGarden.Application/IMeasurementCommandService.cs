using PSK.SmartGarden.Dto.Measurement;

namespace PSK.SmartGarden.Application
{
    public interface IMeasurementCommandService
    {
        InsertMeasurementOutputDto InsertMeasurement(InsertMeasurementInputDto input);
    }
}