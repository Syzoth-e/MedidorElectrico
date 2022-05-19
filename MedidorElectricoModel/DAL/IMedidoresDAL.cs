using MedidorElectricoModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorElectricoModel.DAL
{
    public interface IMedidoresDAL
    {
        List<Medidor> ObtenerMedidores();
    }
}
