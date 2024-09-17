using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.Areceber;
using ControleFacil.Api.Damain.Services.Interface;
using ControleFacil.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    [ApiController]
    [Route("titulosareceber")]
    public class AreceberController : BaseController
    {
        private readonly IService<AreceberRequestContract, AreceberResponseContract, long> _areceber;
        private long _idUser;

        public AreceberController(IService<AreceberRequestContract, AreceberResponseContract, long> areceber)
        {
            _areceber = areceber;
        }

        #region  Insert
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Insert(AreceberRequestContract entidade)
        {
            try
            {
                _idUser = GetUserLoginId();
                return Created("", await _areceber.Insert(entidade: entidade, idUser: _idUser));
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
        public async Task<IActionResult> Update(long id, AreceberRequestContract contract)
        {
            try
            {
                _idUser = GetUserLoginId();
                return Ok(await _areceber.Update(id:id,entidade: contract, idUser: _idUser));
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
                await _areceber.Inativar(id: id, idUser: _idUser);
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
                return Ok(await _areceber.Obter(idUser: _idUser));
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
                return Ok(await _areceber.Obter(id: id, idUser: _idUser));
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
    }
}