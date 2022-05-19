using MedidorElectricoModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorElectricoModel.DAL
{
    public class LecturaDALArchivos : ILecturaDAL
    {
        private LecturaDALArchivos()
        {

        }

        private static LecturaDALArchivos instancia;

        public static ILecturaDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new LecturaDALArchivos();
            }
            return instancia;
        }

        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/lecturas.txt";
        public void IngresarLectura(Lectura lectura)
        {
            
            try
            {
                Boolean existeMedidor = false;
                MedidoresDAL medidoresDal = new MedidoresDAL();
                List<Medidor> medidores = medidoresDal.ObtenerMedidores();
                foreach(Medidor medidor in medidores){
                    if(medidor.NroMedidor == lectura.NroMedidor){
                        existeMedidor=true;
                    }
                }
                if(existeMedidor)
                {
                    using (StreamWriter writer = new StreamWriter(archivo, true))
                    {
                        writer.WriteLine(lectura.NroMedidor + "|" + lectura.Fecha + "|" + lectura.ValorConsumo);
                        writer.Flush();
                    }
                }else{
                    Console.WriteLine("ERROR, NO EXISTE MEDIDOR");
                }
                }
            catch (Exception)
            {

            }
        }
        public List<Lectura> ObtenerLecturas()
        {
            List<Lectura> lista = new List<Lectura>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = "";
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null && texto.Length > 0)
                        {
                            string[] arr = texto.Trim().Split('|');
                            Lectura Lectura = new Lectura()
                            {
                                NroMedidor = Convert.ToUInt32(arr[0]),
                                Fecha = Convert.ToDateTime(arr[1]),
                                ValorConsumo = Convert.ToDouble(arr[2])
                            };
                            lista.Add(Lectura);
                        }
                    } while (texto != null);

                }
            }
            catch (Exception)
            {
                lista = null;
            }
            return lista;
        }

    }
}
