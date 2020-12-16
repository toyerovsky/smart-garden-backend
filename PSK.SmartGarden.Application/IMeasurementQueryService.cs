using System.Threading.Tasks;
using PSK.SmartGarden.Dto.Measurement;

namespace PSK.SmartGarden.Application
{
    public interface IMeasurementQueryService
    {
        GetMeasurementListOutputDto GetMeasurementList(GetMeasurementListInputDto input);
    }
}