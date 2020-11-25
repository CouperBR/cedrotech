using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI
{
    public class Context : DbContext
    {
        
        public Context(DbContextOptions<Context> opcoes)
            : base(opcoes)
        { }

        public virtual DbSet<restaurante> restaurante { get; set; }
        public virtual DbSet<prato> prato { get; set; }
    }
}
