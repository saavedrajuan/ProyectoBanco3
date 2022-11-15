using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBanco1
{
    public class CajaDeAhorro
    {
        public int id { get; set; }
        public int cbu { get; set; }
        public double saldo { get; set; }

        public List<Usuario> titulares { get; set; }
        public List<Movimiento> movimientos { get; set; }

        public CajaDeAhorro(int id, int cbu, double saldo)
        {
            this.id = id;
            this.cbu = cbu;
            this.saldo = saldo;

            this.titulares = new List<Usuario>();
            this.movimientos = new List<Movimiento>();
        }
        public override string ToString()
        {
            return cbu + " - $" + saldo;
        }
    }
}
