
using AutoMapper;
using System.Application.Main.Dtos.Main.MaestroModule;
using System.Domain.Entities.MaestroModule;

namespace System.Application.Service.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            #region Main
            CreateMap<CustomerEntity, OutCustomerDto>();

            CreateMap<CustomerByIdDto, CustomerIdRequestEntity>();
            CreateMap<CustomerIdEntity, OutCustomerDto>();

            CreateMap<NewCustomerDto, NewCustomerRequestEntity>();
            CreateMap<MessageEntity, OutMessageDto>();
            #endregion

        }
    }
}
