using PSK.SmartGarden.Dto.Measurement;

namespace PSK.SmartGarden.Dto.Base
{
    public class BasePageableSortableListInputDto : BasePageableListInputDto
    {
        public SortDirectionDto SortDirection { get; set; }
        
        public enum SortDirectionDto
        {
            Asc,
            Desc
        }
    }
}