using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PSK.SmartGarden.Data.Input;
using PSK.SmartGarden.Data.Repository;
using PSK.SmartGarden.Dto.Measurement;

namespace PSK.SmartGarden.Application
{
    class MeasurementQueryService : IMeasurementQueryService
    {
        private readonly IMeasurementRepository _measurementRepository;
        private readonly IMapper _mapper;

        public MeasurementQueryService(
            IMeasurementRepository measurementRepository,
            IMapper mapper)
        {
            _measurementRepository = measurementRepository;
            _mapper = mapper;
        }

        public GetMeasurementListOutputDto GetMeasurementList(GetMeasurementListInputDto input)
        {
            var dataInput = _mapper.Map<GetMeasurementListInput>(input);

            var results = _measurementRepository.GetMeasurementList(dataInput, out long totalCount);

            return new GetMeasurementListOutputDto
            {
                Data = _mapper.Map<IList<GetMeasurementListOutputDto.ListItemDto>>(results),
                TotalCount = totalCount
            };
        }
    }
}