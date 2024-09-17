using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Contract.NaturezaLancamento;
using ControleFacil.Api.Damain.Services.Interface;
using ControleFacil.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    [ApiController]
    [Route("naturezalancamento")]
    public class NaturezaLancamentoController : BaseController
    {
        private readonly IService<NaturezaLancamentoRequestContract, NaturezaLancamentoResponseContract, long> _nl;
        private long _idUser;

        public NaturezaLancamentoController(IService<NaturezaLancamentoRequestContract, NaturezaLancamentoResponseContract, long> nl)
        {
            _nl = nl;
        }

        #region  Insert
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Insert(NaturezaLancamentoRequestContract entidade)
        {
            try
            {
                _idUser = GetUserLoginId();
                return Created("", await _nl.Insert(entidade: entidade, idUser: _idUser));
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
        public async Task<IActionResult> Update(long id, NaturezaLancamentoRequestContract contract)
        {
            try
            {
                _idUser = GetUserLoginId();
                return Ok(await _nl.Update(id:id,entidade: contract, idUser: _idUser));
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
                await _nl.Inativar(id: id, idUser: _idUser);
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
                return Ok(await _nl.Obter(idUser: _idUser));
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
                return Ok(await _nl.Obter(id: id, idUser: _idUser));
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