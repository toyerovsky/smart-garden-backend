using System;
using AutoMapper;
using PSK.SmartGarden.Data;
using PSK.SmartGarden.Data.Repository;
using PSK.SmartGarden.Dto.Measurement;

namespace PSK.SmartGarden.Application
{
    class MeasurementCommandService : IMeasurementCommandService
    {
        private readonly IMeasurementRepository _measurementRepository;
        private readonly IMapper _mapper;

        public MeasurementCommandService(IMeasurementRepository measurementRepository, IMapper mapper)
        {
            _measurementRepository = measurementRepository;
            _mapper = mapper;
        }

        public InsertMeasurementOutputDto InsertMeasurement(InsertMeasurementInputDto input)
        {
            var measurement = _mapper.Map<MeasurementEntity>(input);
            measurement.Date = DateTime.UtcNow;

            var id = _measurementRepository.InsertMeasurement(measurement);

            return new InsertMeasurementOutputDto
            {
                Id = id
            };
        }
    }
}