using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAbadBurguerPromoCF.Models;

namespace SAbadBurguerPromoCF.Data
{
    public class SAbadBurguerPromoCFContext : DbContext
    {
        public SAbadBurguerPromoCFContext (DbContextOptions<SAbadBurguerPromoCFContext> options)
            : base(options)
        {
        }

        public DbSet<SAbadBurguerPromoCF.Models.Burguer> Burguer { get; set; } = default!;
    }
}
