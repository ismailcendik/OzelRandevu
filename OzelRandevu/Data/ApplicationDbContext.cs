using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OzelRandevu.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzelRandevu.Data
{
    public class ApplicationDbContext : IdentityDbContext<Ozel_Randevu_Kullanicilar, Ozel_Randevu_Roller,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ozel_Randevu> OzelRandevular { get; set; }
    }
}
