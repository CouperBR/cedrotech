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
            var pedidos = _context.pedido.ToList();
            return pedidos;
        }

        public void Save(pedido pedido)
        {
            _context.endereco.Add(pedido.endereco);
            _context.SaveChanges();

            pedido.enderecoId = pedido.endereco.id;
            _context.pedido.Add(pedido);
            _context.SaveChanges();
            foreach (var prato in pedido.pratos)
            {
                var pp = new prato_pedido
                {
                    prato = prato,
                    quantidade = prato.quantidade,
                    pedido = pedido,
                    id_pedido = pedido.id,
                    id_prato = prato.id
                };

                _context.prato_pedido.Add(pp);
            }

            _context.SaveChanges();
        }
    }
}
