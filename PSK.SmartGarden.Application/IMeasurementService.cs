using System.Threading.Tasks;

namespace PSK.SmartGarden.Application
{
    public interface IMeasurementService
    {
        GetMeasurementListOutputDto GetMeasurementList(GetMeasurementListInputDto input);
    }
}