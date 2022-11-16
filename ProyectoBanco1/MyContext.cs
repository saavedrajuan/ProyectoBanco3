using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBanco1
{
    public class MyContext : DbContext
    {
        public DbSet<Usuario> usuarios;
        public DbSet<CajaDeAhorro> cajas;
        public DbSet<PlazoFijo> pfs;
        public DbSet<TarjetaDeCredito> tarjetas;
        public DbSet<Pago> pagos;
        public DbSet<Movimiento> movimientos;
        public DbSet<UsuarioCaja> usuarioCaja;

        public MyContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Resources.connectionStr);
        }

    }
}
