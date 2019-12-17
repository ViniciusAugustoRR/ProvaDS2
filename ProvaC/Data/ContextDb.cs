using Microsoft.EntityFrameworkCore;
using ProvaC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaC.Data
{
    public class ContextDb : DbContext
    {

        public ContextDb(DbContextOptions<ContextDb> options)
          : base(options)
        {
        }

        public DbSet<Jogador> Jogadores { get; set; }

        public DbSet<Placar> Placares { get; set; }


    }
}
