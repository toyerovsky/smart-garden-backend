using System.Collections.Generic;
using System.Threading.Tasks;
using PSK.SmartGarden.Data.Input;

namespace PSK.SmartGarden.Data.Repository
{
    public interface IMeasurementRepository
    {
        IList<MeasurementEntity> GetMeasurementList(GetMeasurementListInput input);
    }
}