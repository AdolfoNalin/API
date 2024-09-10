using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.Usuario;
using ControleFacil.Api.Damain.Services.Class;
using ControleFacil.Api.Damain.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuairoController : BaseController
    {
        private IUsuarioService _usuarioService;
        public UsuairoController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar(UsuarioLoginRequestContract usuarioLogin)
        {
            try
            {
                return Created("", await _usuarioService.Autenticar(usuarioLogin));
            }
            catch (AuthenticationException ex)
            {
                return Unauthorized(new {statusCode = 401, message = ex.Message});
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        #region Insert
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Insert(UsuarioRequestContract contrato)
        {
            try
            {
                return Created("",await _usuarioService.Insert(contrato, 0));
            }
            catch(ArgumentNullException)
            {
                return Problem("Erro algum dos argumentos estão nulos");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }
        #endregion

        #region Obter
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Obter()
        {
            try
            {
                long idUser = 0;
                return Ok(await _usuarioService.Obter(idUser));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Obter Email
        [HttpGet("{email}")]
        [Authorize]
        public async Task<IActionResult> Obter(string email)
        {
            try
            {
                return Ok(await _usuarioService.Obter(email));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Obter id
        [HttpGet("usuario/{id}")]
        [Authorize]
        public async Task<IActionResult> Obter(long id)
        {
            try
            {
                return Ok(await _usuarioService.Obter(id: 0, idUser: id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(long id,UsuarioRequestContract contrato)
        {
            try
            {
                return Ok(await _usuarioService.Update(id,contrato, 0));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task <IActionResult> Delete(long id)
        {
            try
            {
                await _usuarioService.Inativar(id, 0);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion
    }
}