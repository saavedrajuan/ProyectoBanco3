using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBanco1
{
    public class Usuario
    {
        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }
        public bool esAdmin { get; set; }

        public List<CajaDeAhorro> cajas { get; set; }
        public List<PlazoFijo> pfs { get; set; }
        public List<TarjetaDeCredito> tarjetas { get; set; }
        public List<Pago>? pagos { get; set; }

        public Usuario() { }
        public Usuario(int id, int dni, string nombre, string apellido, string mail, string password, int intentosFallidos, bool bloqueado, bool esAdmin)
        {
            this.id = id;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.password = password;
            this.intentosFallidos = intentosFallidos;
            this.bloqueado = bloqueado;
            this.esAdmin = esAdmin;

            cajas = new List<CajaDeAhorro>();  
            pfs = new List<PlazoFijo>();
            tarjetas = new List<TarjetaDeCredito>();
            pagos = new List<Pago>();
        }
        public override string ToString()
        {
            return id + ", " + dni + ", " + nombre + ", " + apellido + ", " + mail + ", " + bloqueado;
        }
    }
}
