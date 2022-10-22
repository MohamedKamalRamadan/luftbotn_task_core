using AutoMapper;
using Inv_Task.Core.Model;
using Inv_Task.Core.ViewModel;

namespace Inv_Task.mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Inv_Master, Inv_MasterDTO>();
            CreateMap<Inv_Details, Inv_DetailsDTO>();
            CreateMap<Items, ItemsDTO>();
            CreateMap<Customers, CustomerDTO>();
        }
    }

}
