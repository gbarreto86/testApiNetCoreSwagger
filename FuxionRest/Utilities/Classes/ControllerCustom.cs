using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackFuxion.Utilities.Classes
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Search")]
    [Produces("application/json")]
    [Route("api/db/[controller]/[action]")]
    public class ControllerCustom : Controller
    {

    }
}
