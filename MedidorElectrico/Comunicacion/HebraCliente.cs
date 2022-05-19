using MedidorElectricoModel.DAL;
using MedidorElectricoModel.DTO;
using ServerSocketUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorElectrico.Comunicacion
{
    public class HebraCliente
    {
        private ClienteCom clienteCom;

        private static ILecturaDAL lecturasDAL = LecturaDALArchivos.GetInstancia();

        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void Ejecutar()
        {
            clienteCom.Escribir("Ingrese lectura : ");
            string leer = clienteCom.Leer();
            string[] arr = leer.Trim().Split('|');

            Lectura lectura = new Lectura()
            {
                NroMedidor = Convert.ToUInt32(arr[0]),
                Fecha = DateTime.ParseExact(arr[1], "yyyy-MM-dd-HH-mm-ss", null),
                ValorConsumo = Convert.ToDouble(arr[2])
            };
            lock (lecturasDAL)
            {
                lecturasDAL.IngresarLectura(lectura);
            }
            clienteCom.Desconectar();
        }
    }
}

