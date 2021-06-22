using HoteldeMascotas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoteldeMascotas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dueños> dueño { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Mascotas> Mascota { get; set; }

    }
}
