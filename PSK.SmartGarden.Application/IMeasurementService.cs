using System.Threading.Tasks;
using PSK.SmartGarden.Dto.Measurement;

namespace PSK.SmartGarden.Application
{
    public interface IMeasurementService
    {
        GetMeasurementListOutputDto GetMeasurementList(GetMeasurementListInputDto input);
    }
}