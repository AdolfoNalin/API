using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ControleFacil.Api.Contract;
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

        protected ModelErrorContract GetBadRequest(Exception ex)
        {
            return new ModelErrorContract{
                    StatusCode = 400,
                    Title = "Bad Request",
                    Message = ex.Message,
                    DateTime = DateTime.Now,
                };
        }

        protected ModelErrorContract GetNotFoud(Exception ex)
        {
            return new ModelErrorContract{
                    StatusCode = 404,
                    Title = "NotFoud",
                    Message = ex.Message,
                    DateTime = DateTime.Now,
                };
        }

        protected ModelErrorContract Unauthorized(Exception ex)
        {
            return new ModelErrorContract{
                    StatusCode = 401,
                    Title = "Bad Request",
                    Message = ex.Message,
                    DateTime = DateTime.Now,
                };
        }

        protected ModelErrorContract InternalServerError(Exception ex)
        {
            return new ModelErrorContract{
                    StatusCode = 500,
                    Title = "Internal Sever Error",
                    Message = ex.Message,
                    DateTime = DateTime.Now,
                };
        }
    }
}