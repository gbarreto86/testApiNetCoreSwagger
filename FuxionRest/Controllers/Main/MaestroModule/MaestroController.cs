using AutoMapper;
using ApiBackFuxion.Utilities.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Application.Main.Dtos.Main.MaestroModule;
using System.Application.Main.Services.MaestroModule;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiBackFuxion.Controllers.Main.Maestro
{
    public class MaestroController : ControllerCustom
    {
        private IMaestroService _maestroService;
        private IMapper _mapper;

        public MaestroController(IMaestroService maestroService,
                                 IMapper mapper)
        {
            _maestroService = maestroService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "lista a todos los cliente")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, null, Description = "error al comunicarse con el servidor")]
        public async Task<IActionResult> GetCustomer()
        {
            try
            {
                return Ok(await _maestroService.GetCustomer());
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor");
            }
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, /*Type = typeof(CustomerByIdDto),*/ Description = "lista a un cliente por ID")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, null, Description = "error al comunicarse con el servidor")]
        public async Task<IActionResult> GetCustomerByID(int ID)
        {
            CustomerByIdDto objParametros = new CustomerByIdDto();
            objParametros.customerID = ID;
            try
            {
                return Ok(await _maestroService.GetCustomerByID(objParametros));
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor");
            }
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(NewCustomerDto), Description = "crear un nuevo cliente")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, null, Description = "error al comunicarse con el servidor")]
        public async Task<IActionResult> NewCustomer([FromBody] NewCustomerDto objParametros)
        {
            try
            {
                return Ok(await _maestroService.NewCustomer(objParametros));
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor");
            }
        }
    }
}
