using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected long GetUserLoginId()
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            long.TryParse(id, out long idUser);

            return idUser;
        }
    }
}