using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBanco1
{
    public class UsuarioCaja
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idCaja { get; set; }


        public UsuarioCaja(int id, int idU, int idC)
        {
            this.id = id;
            this.idUsuario = idU;
            this.idCaja = idC;
        }


    }
}
