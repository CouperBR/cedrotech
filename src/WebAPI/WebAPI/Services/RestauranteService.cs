using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class RestauranteService : IRestauranteService
    {
        private readonly Context _context;
        public RestauranteService(Context context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.restaurante.Remove(_context.restaurante.Find(id));
            _context.SaveChanges();
        }

        public List<restaurante> Get(string nome = "")
        {
            var restaurante = _context.restaurante.AsQueryable();
            if (!string.IsNullOrEmpty(nome))
                restaurante = restaurante.Where(res => res.nome.Contains(nome));
            return restaurante.ToList();
        }

        public restaurante Get(int id)
        {
            var restaurante = _context.restaurante.Find(id);
            if (restaurante == null)
            {
                throw new Exception("Restaurante não encontrato.");
            }

            return restaurante;
        }

        public void Save(restaurante prato)
        {
            _context.restaurante.Add(prato);
            _context.SaveChanges();
        }

        public void Update(int id, restaurante prato)
        {
            var oldRestaurante = _context.restaurante.Find(id);
            if (oldRestaurante == null)
            {
                throw new Exception("Restaurante não encontrato.");
            }

            var newRestaurante = prato;
            oldRestaurante.nome = newRestaurante.nome;
            _context.Entry(oldRestaurante).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
