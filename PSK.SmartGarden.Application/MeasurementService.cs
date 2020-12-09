using System;
using System.Threading.Tasks;
using PSK.SmartGarden.Data.Repository;

namespace PSK.SmartGarden.Application
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _measurementRepository;

        public MeasurementService(IMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }

        public GetMeasurementListOutputDto GetMeasurementList(GetMeasurementListInputDto input)
        {
            return new GetMeasurementListOutputDto();
        }
    }
}