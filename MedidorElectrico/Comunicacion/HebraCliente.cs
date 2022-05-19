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
            clienteCom.Escribir("Ingrese Nro Medidor : ");
            uint nroMedidor = Convert.ToUInt32(clienteCom.Leer());
            clienteCom.Escribir("Ingrese fecha: ");
            DateTime fecha = Convert.ToDateTime(clienteCom.Leer());
            clienteCom.Escribir("Ingrese valor consumo: ");
            double valorConsumo = Convert.ToDouble(clienteCom.Leer());
            Lectura lectura = new Lectura()
            {
                NroMedidor = nroMedidor,
                Fecha = fecha,
                ValorConsumo = valorConsumo
            };
            lock (lecturasDAL)
            {
                lecturasDAL.IngresarLectura(lectura);
            }
            clienteCom.Desconectar();
        }
    }
}

