using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController : Controller
    {
        protected readonly Context _context;

        public PratoController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string nome = "")
        {
            try
            {
                var prato = _context.prato.AsQueryable();
                if (!string.IsNullOrEmpty(nome))
                    prato = prato.Where(pr => pr.nome.Contains(nome));
                return Json(prato.Include(pr => pr.restaurante).ToList());
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
                var prato = _context.prato.Find(id);
                if (prato == null)
                {
                    return StatusCode(500, "Prato não encontrato.");
                }

                return Json(prato);
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
                _context.prato.Add(JsonConvert.DeserializeObject<prato>(data));
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
                var oldPrato =_context.prato.Find(id);
                if (oldPrato == null)
                {
                    return StatusCode(500, "Prato não encontrato.");
                }

                var newPrato = JsonConvert.DeserializeObject<prato>(data);
                oldPrato.nome = newPrato.nome;
                oldPrato.preco = newPrato.preco;
                oldPrato.restaurante = _context.restaurante.Find(newPrato.restauranteId);
                _context.Entry(oldPrato).State = EntityState.Modified;
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
                _context.prato.Remove(_context.prato.Find(id));
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