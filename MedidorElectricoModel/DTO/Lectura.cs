using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorElectricoModel.DTO
{
    public class Lectura
    {
        private uint nroMedidor;
        private DateTime fecha;
        private double valorConsumo;

        public uint NroMedidor { get => nroMedidor; set => nroMedidor = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double ValorConsumo { get => valorConsumo; set => valorConsumo = value; }

        public override string ToString()
        {
            return nroMedidor + "|" + fecha.ToString("dd-MM-yyyy-HH-mm-s") + "|" + valorConsumo;
        }
    }
}
