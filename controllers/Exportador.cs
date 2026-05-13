using System;
using System.Collections.Generic;
using System.IO;

namespace TP2Autos.Controllers
{
    public class Exportador
    {
        public void ExportarTXT(List<string> lineas, string ruta)
        {
            try
            {
                StreamWriter archivo = new StreamWriter(ruta);

                foreach (string linea in lineas)
                {
                    archivo.WriteLine(linea);
                }

                archivo.Close();

                Console.WriteLine("Archivo exportado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al exportar: " + ex.Message);
            }
        }
    }
}