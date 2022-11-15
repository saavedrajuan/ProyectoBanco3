using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBanco1
{
    public class TarjetaDeCredito
    {
        public int id { get; set; }
        public int titular { get; set; }
        public int numero { get; set; }
        public int codigoV { get; set; }
        public double limite { get; set; }
        public double consumos { get; set; }

        public TarjetaDeCredito(int id, int titular, int numero, int codigoV, double limite, double consumos)
        {
            this.id = id;
            this.titular = titular;
            this.numero = numero;
            this.codigoV = codigoV;
            this.limite = limite;
            this.consumos = consumos;
        }
    }
}

