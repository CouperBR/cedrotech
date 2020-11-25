using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : Controller
    {
        protected readonly Context _context;

        public RestauranteController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string nome = "")
        {
            try
            {
                var restaurante = _context.restaurante.AsQueryable();
                if (!string.IsNullOrEmpty(nome))
                    restaurante = restaurante.Where(res => res.nome.Contains(nome));
                return Json(restaurante.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var restaurante = _context.restaurante.Find(id);
                if (restaurante == null)
                {
                    return StatusCode(500, "Restaurante não encontrato.");
                }

                return Json(restaurante);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(string data)
        {
            try
            {
                _context.restaurante.Add(JsonConvert.DeserializeObject<restaurante>(data));
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, string data)
        {
            try
            {
                var oldRestaurante = _context.restaurante.Find(id);
                if (oldRestaurante == null)
                {
                    return StatusCode(500, "Restaurante não encontrato.");
                }

                var newRestaurante = JsonConvert.DeserializeObject<restaurante>(data);
                oldRestaurante.nome = newRestaurante.nome;
                _context.Entry(oldRestaurante).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _context.restaurante.Remove(_context.restaurante.Find(id));
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}