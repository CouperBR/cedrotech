using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class pedido
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public virtual endereco endereco { get; set; }

        [ForeignKey("endereco")]
        public int enderecoId { get; set; }

        public virtual IList<prato> pratos { get; set; }

        public decimal total { get; set; }

        public virtual IList<prato_pedido> prato_pedido { get; set; }
    }
}
