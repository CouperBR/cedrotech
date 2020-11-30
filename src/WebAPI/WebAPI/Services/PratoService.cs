using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class PratoService : IPratoService
    {
        protected readonly Context _context;

        public PratoService(Context context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.prato.Remove(_context.prato.Find(id));
            _context.SaveChanges();
        }

        public List<prato> Get(string nome = "")
        {
            var prato = _context.prato.AsQueryable();
            if (!string.IsNullOrEmpty(nome))
                prato = prato.Where(pr => pr.nome.Contains(nome));
            return prato.Include(pr => pr.restaurante).ToList();
        }

        public prato Get(int id)
        {
            var prato = _context.prato.Find(id);
            if (prato == null)
            {
                throw new Exception("Prato não encontrato.");
            }
            return prato;
        }

        public void Save(prato prato)
        {
            _context.prato.Add(prato);
            _context.SaveChanges();
        }

        public void Update(int id, prato prato)
        {
            var oldPrato = _context.prato.Find(id);
            if (oldPrato == null)
            {
                throw new Exception("Prato não encontrado.");
            }

            var newPrato = prato;
            oldPrato.nome = newPrato.nome;
            oldPrato.preco = newPrato.preco;
            oldPrato.restaurante = _context.restaurante.Find(newPrato.restauranteId);
            _context.Entry(oldPrato).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
