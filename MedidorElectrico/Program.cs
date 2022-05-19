 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedidorElectricoModel.DTO;
using System.Threading.Tasks;
using MedidorElectricoModel.DAL;
using MedidorElectrico.Comunicacion;
using System.Threading;

namespace MedidorElectrico
{
    class Program
    {
        private static ILecturaDAL lecturaDAL = LecturaDALArchivos.GetInstancia();
        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("¿Que quiere hacer?");
            Console.WriteLine(" 1. Ingresar lectura \n 2. Mostrar lecturas \n 0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    IngresarLectura();
                    break;
                case "2":
                    MostrarLectura();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Ingrese de nuevo");
                    break;
            }
            return continuar;
        }
        static void Main(string[] args)
        {
            HebraServidor hebra = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.IsBackground = true;
            t.Start();
            while (Menu()) ;
        }
          static void MostrarLectura()
        {
            List<Lectura> lecturas = null;
            lock (lecturaDAL)
            {
                lecturas = lecturaDAL.ObtenerLecturas();
            };
            if(lecturas != null && lecturas.Count > 0)
            {
                foreach (Lectura lectura in lecturas)
                {
                    Console.WriteLine(lectura);
                }
            }
            else
            {
                Console.WriteLine("NO SE ENCUENTRAN LECTURAS");
            }
        }

        static void IngresarLectura()
        {
            Console.WriteLine("Ingrese medidor: ");
            uint nroMedidor = Convert.ToUInt32(Console.ReadLine().Trim());
            Console.WriteLine("Ingrese fecha: ");
            DateTime fecha = Convert.ToDateTime(Console.ReadLine().Trim());
            Console.WriteLine("Ingrese valor consumo: ");
            double valorConsumo = Convert.ToDouble(Console.ReadLine().Trim());
            Lectura lectura = new Lectura()
            {
                NroMedidor = nroMedidor,
                Fecha = fecha,
                ValorConsumo = valorConsumo
            };
            lock (lecturaDAL)
            {
                lecturaDAL.IngresarLectura(lectura);
            }
        }
    }
}
