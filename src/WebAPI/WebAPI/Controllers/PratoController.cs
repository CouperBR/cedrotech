using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController : Controller
    {
        protected readonly IPratoService _pratoService;

        public PratoController(IPratoService pratoService)
        {
            _pratoService = pratoService;
        }

        /// <summary>
        /// Retorna pratos por um nome, ou não.
        /// </summary>
        [HttpGet]
        public IActionResult Get(string nome = "")
        {
            try
            {
                return Json(_pratoService.Get(nome));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Retorna um prato pelo id.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Json(_pratoService.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Cria um novo prato.
        /// </summary>
        [HttpPost]
        public IActionResult Post(prato data)
        {
            try
            {
                _pratoService.Save(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Salva um prato já existente.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, prato data)
        {
            try
            {
                _pratoService.Update(id, data);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deleta um prato.
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _pratoService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}