using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practica1.Models;

namespace Practica1.Data
{
    public class Practica1Context : DbContext
    {
        public Practica1Context(DbContextOptions<Practica1Context> options) : base(options)
        {

        }

        public DbSet<Artista> Artista{ get; set; }

        public DbSet<Album> Album { get; set; }

        public DbSet<Practica1.Models.Cancion> Cancion { get; set; }
    }
}
