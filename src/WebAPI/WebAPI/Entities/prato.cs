using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class prato
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string nome { get; set; }

        public decimal preco { get; set; }

        public virtual restaurante restaurante { get; set; }

        [ForeignKey("restaurante")]
        public int restauranteId { get; set; }
        
        public int quantidade { get; set; }
    }
}
