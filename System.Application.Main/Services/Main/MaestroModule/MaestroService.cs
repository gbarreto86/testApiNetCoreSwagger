using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Application.Main.Dtos.Main.MaestroModule;
using System.Application.Main.Helpers;
using System.Collections.Generic;
using System.Domain.Entities.MaestroModule;
using System.Domain.Interfaces.MaestroModule;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace System.Application.Main.Services.MaestroModule
{
    public class MaestroService : IMaestroService
    {
        private readonly IMaestroRepository _maestroRepository;
        private IMapper _mapper;

        public MaestroService(IMaestroRepository maestroRepository,
                              IMapper mapper)
        {
            _maestroRepository = maestroRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OutCustomerDto>> GetCustomer()
        {
            //Crear dto
            IEnumerable<OutCustomerDto> oItemDto = null;
            try
            {
                var result = await _maestroRepository.GetCustomer();
                oItemDto = _mapper.Map<IEnumerable<OutCustomerDto>>(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex.StackTrace);

            }
            return oItemDto;
        }

        public async Task<IEnumerable<OutCustomerDto>> GetCustomerByID(CustomerByIdDto objParameters)
        {
            //Crear dto
            IEnumerable<OutCustomerDto> oItemDto = null;
            try
            {
                var result = await _maestroRepository.GetCustomerByID(_mapper.Map<CustomerIdRequestEntity>(objParameters));
                oItemDto = _mapper.Map<IEnumerable<OutCustomerDto>>(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex.StackTrace);

            }
            return oItemDto;
        }

        public async Task<IEnumerable<OutMessageDto>> NewCustomer(NewCustomerDto objParametros)
        {
            //Crear dto
            IEnumerable<OutMessageDto> oItemDto = null;
            try
            {
                var result = await _maestroRepository.NewCustomer(_mapper.Map<NewCustomerRequestEntity>(objParametros));
                oItemDto = _mapper.Map<IEnumerable<OutMessageDto>>(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex.StackTrace);

            }
            return oItemDto;
        }

    }
}
