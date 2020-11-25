using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class restaurante
    {
        public int id { get; set; }
        public string nome { get; set; }
    }
}
