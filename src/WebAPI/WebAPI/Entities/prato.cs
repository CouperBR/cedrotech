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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string nome { get; set; }

        public decimal preco { get; set; }

        public restaurante restaurante { get; set; }

        [ForeignKey("restaurante")]
        public int restauranteId { get; set; }

        [NotMapped]
        public int quantidade { get; set; }

    }
}
