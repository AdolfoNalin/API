using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Contract;
using ControleFacil.Api.Contract.Apagar;
using ControleFacil.Api.Damain.Services.Interface;
using ControleFacil.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControleFacil.Api.Controllers
{
    [ApiController]
    [Route("titulosapagar")]
    public class ApagarController : BaseController
    {
        private readonly IService<ApagarRequestContract, ApagarResponseContract, long> _apagar;
        private long _idUser;

        public ApagarController(IService<ApagarRequestContract, ApagarResponseContract, long> apagar)
        {
            _apagar = apagar;
        }

        #region  Insert
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Insert(ApagarRequestContract entidade)
        {
            try
            {
                _idUser = GetUserLoginId();
                return Created("", await _apagar.Insert(entidade: entidade, idUser: _idUser));
            }
            catch(BadRequestExceptions br)
            {
                return BadRequest(GetBadRequest(br));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion
    
        #region Update
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(long id, ApagarRequestContract contract)
        {
            try
            {
                _idUser = GetUserLoginId();
                return Ok(await _apagar.Update(id:id,entidade: contract, idUser: _idUser));
            }
            catch(NotFoundExceptions ex)
            {
                return NotFound(GetNotFoud(ex));
            }
            catch(BadRequestExceptions br)
            {
                return BadRequest(GetBadRequest(br));
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
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                _idUser = GetUserLoginId();
                await _apagar.Inativar(id: id, idUser: _idUser);
                return NoContent();
            }
            catch(NotFoundExceptions ex)
            {
                return NotFound(GetNotFoud(ex));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion
    
        #region Obter All
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Obter()
        {
            try
            {
                _idUser = GetUserLoginId();
                return Ok(await _apagar.Obter(idUser: _idUser));
            }
            catch(NotFoundExceptions ex)
            {
                return NotFound(GetNotFoud(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion
    
        #region Obter Id
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Obter(long id)
        {
            try
            {
                _idUser = GetUserLoginId();
                return Ok(await _apagar.Obter(id: id, idUser: _idUser));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        #endregion
    }
}