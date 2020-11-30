using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly Context _context;
        public PedidoService(Context context)
        {
            _context = context;
        }

        public List<pedido> Get()
        {
            var pedidos = _context.pedido.Include(p => p.prato_pedido).ToList();
            return pedidos;
        }

        public void Save(pedido pedido)
        {
            IList<prato> pratos = pedido.pratos;
            _context.endereco.Add(pedido.endereco);
            _context.SaveChanges();

            pedido.enderecoId = pedido.endereco.id;
            pedido.prato_pedido = null;
            pedido.pratos = null;
            _context.pedido.Add(pedido);
            _context.SaveChanges();

            foreach (var prato in pratos)
            {
                var pp = new prato_pedido
                {
                    quantidade = prato.quantidade,
                    id_pedido = pedido.id,
                    id_prato = prato.id
                };

                _context.prato_pedido.Add(pp);
            }

            _context.SaveChanges();
        }
    }
}
