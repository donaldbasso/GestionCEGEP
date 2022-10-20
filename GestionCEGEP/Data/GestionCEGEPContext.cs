using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionCEGEP.Models;

namespace GestionCEGEP.Data
{
    public class GestionCEGEPContext : DbContext
    {
        public GestionCEGEPContext (DbContextOptions<GestionCEGEPContext> options)
            : base(options)
        {
        }

        public DbSet<GestionCEGEP.Models.Cegep> Cegep { get; set; } = default!;
    }
}
