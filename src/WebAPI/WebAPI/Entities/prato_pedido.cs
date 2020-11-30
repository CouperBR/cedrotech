using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class prato_pedido
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public virtual prato prato { get; set; }

        [ForeignKey("prato")]
        public int id_prato { get; set; }

        public virtual pedido pedido { get; set; }

        [ForeignKey("pedido")]
        public int id_pedido { get; set; }

        public int quantidade { get; set; }
    }
}
