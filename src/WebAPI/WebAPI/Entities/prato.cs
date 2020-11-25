using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class prato
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public restaurante restaurante { get; set; }
        public virtual int restauranteId { get; set; }
    }
}
