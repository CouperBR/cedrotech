using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class pedido
    {
        public int id { get; set; }

        public endereco endereco { get; set; }

        [ForeignKey("endereco")]
        public int enderecoId { get; set; }

        [NotMapped]
        public IList<prato> pratos { get; set; }

        public decimal total { get; set; }
    }
}
