using MedidorElectricoModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorElectricoModel.DAL
{
    public class MedidoresDAL : IMedidoresDAL
    {
        private static List<Medidor> medidores = null;
        public MedidoresDAL()
        {
            medidores = new List<Medidor>();
            for (int i = 1; i <= 20; i++)
            {
                medidores.Add(new Medidor(i));
            }
        }

        public List<Medidor> ObtenerMedidores()
        {
           return medidores;
        }
    }
}
