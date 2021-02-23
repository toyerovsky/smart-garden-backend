using AutoMapper;
using PSK.SmartGarden.Data;
using PSK.SmartGarden.Data.Input;
using PSK.SmartGarden.Dto.Measurement;

namespace PSK.SmartGarden.Application.MapperProfiles
{
    public class MeasurementProfile : Profile
    {
        public MeasurementProfile()
        {
            CreateMap<GetMeasurementListInputDto, GetMeasurementListInput>();
            CreateMap<MeasurementEntity, GetMeasurementListOutputDto.ListItemDto>()
                .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToLocalTime()));
        }
    }
}