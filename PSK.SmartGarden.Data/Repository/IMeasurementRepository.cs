using System.Collections.Generic;
using PSK.SmartGarden.Data.Input;

namespace PSK.SmartGarden.Data.Repository
{
    public interface IMeasurementRepository
    {
        IList<MeasurementEntity> GetMeasurementList(GetMeasurementListInput input, out long totalCount);
        string InsertMeasurement(MeasurementEntity measurement);
    }
}