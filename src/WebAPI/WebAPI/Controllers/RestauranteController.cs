using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : Controller
    {
        protected readonly IRestauranteService _restauranteService;

        public RestauranteController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        /// <summary>
        /// Retorna restaurantes, pelo nome ou não.
        /// </summary>
        [HttpGet]
        public IActionResult Get(string nome = "")
        {
            try
            {
                return Json(_restauranteService.Get(nome));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Retorna um restaurante pelo id.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Json(_restauranteService.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Salva um novo restaurante.
        /// </summary>
        [HttpPost]
        public IActionResult Post(restaurante data)
        {
            try
            {
                _restauranteService.Save(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Salva um restaurante já existente.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, restaurante data)
        {
            try
            {
                _restauranteService.Update(id, data);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deleta um restaurante.
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _restauranteService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}