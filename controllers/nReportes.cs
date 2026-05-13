using System;
using System.Collections.Generic;

namespace TP2Autos.Controllers
{
    public class nReportes
    {
        Exportador exportador = new Exportador();

        public void MenuReportes()
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("=== REPORTES ===");
                Console.WriteLine("1- Vehiculos mas usados");
                Console.WriteLine("2- Clientes que mas alquilan");
                Console.WriteLine("3- Exportar reporte");
                Console.WriteLine("0- Volver");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        VehiculosMasUsados();
                        break;

                    case 2:
                        ClientesQueMasAlquilan();
                        break;

                    case 3:
                        ExportarReporte();
                        break;
                }

                Console.ReadKey();

            } while (opcion != 0);
        }

        public void VehiculosMasUsados()
        {
            Console.WriteLine("Pendiente de integrar reservas.");
        }

        public void ClientesQueMasAlquilan()
        {
            Console.WriteLine("Pendiente de integrar reservas.");
        }

        public void ExportarReporte()
        {
            List<string> lineas = new List<string>();

            lineas.Add("Reporte de prueba");
            lineas.Add("Linea 2");

            exportador.ExportarTXT(lineas, "reporte.txt");
        }
    }
}