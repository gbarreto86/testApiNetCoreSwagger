using ApiFuxion.Custom;
using ApiBackFuxion.Utilities.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Application.Main.Dtos.Token;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;

namespace ApiBackFuxion.Controllers
{

    public class SecurityController : ControllerCustomSecurity
    {
        private IToken _token;

        public SecurityController(IToken token)
        {
            _token = token;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TokenDto), Description = "obtener token")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, null, Description = "error al comunicarse con el servidor")]
        public async Task<IActionResult> GetToken([FromBody] TokenDto objToken)
        {

            if (objToken != null)
            {
                var token = await _token.CreateToken(objToken);

                if (!string.IsNullOrEmpty(objToken.Key))
                {
                    return Ok(new
                    {
                        token
                    });
                }

                return BadRequest(new { message = "Credenciales incorrectas", token = "" });

            }
            return BadRequest(new { message = "Credenciales incorrectas", token = "" });

        }


        //[HttpPost]
        //[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TokenOffixDto), Description = "obtener token")]
        //[SwaggerResponse(StatusCodes.Status500InternalServerError, null, Description = "error al comunicarse con el servidor")]
        //public async Task<IActionResult> GetTokenOfix([FromBody] TokenOffixDto objToken)
        //{

        //    if (objToken != null)
        //    {
        //        var token = await _token.CreateTokenOffix(new
        //        {
        //            CustomerID = objToken.CustomerID,
        //            ExpirationDate = DateTime.Now.AddHours(1)
        //        }, objToken.Sistema);
        //        token.CustomerID = objToken.CustomerID;
        //        if (!string.IsNullOrEmpty(objToken.CustomerID))
        //        {
        //            return Ok(new
        //            {
        //                token
        //            });
        //        }

        //        return BadRequest(new { message = "Credenciales incorrectas", token = "" });

        //    }
        //    return BadRequest(new { message = "Credenciales incorrectas", token = "" });

        //}

        //[HttpPost]
        //[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TokenOffixDto), Description = "obtener token")]
        //[SwaggerResponse(StatusCodes.Status500InternalServerError, null, Description = "error al comunicarse con el servidor")]
        //public async Task<IActionResult> GetTokenSilent([FromBody] TokenOffixDto objToken)
        //{

        //    if (objToken != null)
        //    {
        //        var token = await _token.CreateTokenOffixV2(new
        //        {
        //            CustomerID = objToken.CustomerID,
        //            ExpirationDate = DateTime.Now.AddHours(1)
        //        }, objToken.Sistema);
        //        token.CustomerID = objToken.CustomerID;
        //        if (!string.IsNullOrEmpty(objToken.CustomerID))
        //        {
        //            return Ok(new
        //            {
        //                token
        //            });
        //        }

        //        return BadRequest(new { message = "Credenciales incorrectas", token = "" });

        //    }
        //    return BadRequest(new { message = "Credenciales incorrectas", token = "" });

        //}
    }
}
