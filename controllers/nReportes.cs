using System;
using System.Collections.Generic;
using System.Linq;
using alquiler_de_autos.models;

namespace alquiler_de_autos.controllers
{
    public class nReportes
    {
        Exportador exportador = new Exportador();
        
        public void VehiculosMasUsados(List<Reserva> reservas)
        {
            Console.WriteLine("Vehiculos mas usados");
            if (reservas.Count == 0)
            {
                Console.WriteLine("No hay reservas registradas.");
                return;
            }
        
        var consulta = reservas
                .GroupBy(r => r.vehiculo.patente)
                .Select(grupo => new { 
                    Patente = grupo.Key, 
                    Cant = grupo.Count(), 
                    Auto = grupo.First().vehiculo 
                })
                .OrderByDescending(x => x.Cant);
            
            foreach (var item in consulta)
            {
                Console.WriteLine($"Patente: {item.Patente}, Cantidad de reservas: {item.Cant}, Marca: {item.Auto.marca}, Modelo: {item.Auto.modelo}");
            }
        }

        public void ClientesQueMasAlquilan(List<Reserva> reservas)
        {
            Console.WriteLine("Clientes Frecuentes");
            if (reservas.Count == 0)
            {
                Console.WriteLine("No hay reservas registradas.");
                return;
            }

            var consulta = reservas
                .GroupBy(r => r.cliente.DNI)
                .Select(grupo => new { 
                    DNI = grupo.Key, 
                    Cant = grupo.Count(), 
                    Nombre = grupo.First().cliente.Apellido 
                })
                .OrderByDescending(x => x.Cant);

            foreach (var item in consulta)
            {
                Console.WriteLine($"DNI: {item.DNI}, Cantidad de reservas: {item.Cant}, Nombre: {item.Nombre}");
            }
        }

        public void ExportarReporte(List<Reserva> reservas)
        {
            List<string> lineas = new List<string>();
            lineas.Add("Reporte de reservas");
            lineas.Add($"Fecha en la que se genera: {DateTime.Now}");

            foreach (var r in reservas)
            {
                lineas.Add($"Auto: {r.vehiculo.patente} | Cliente: {r.cliente.DNI} | Desde: {r.fechaInicio.ToShortDateString()}");
            }
    
            exportador.ExportarTXT(lineas, "reporteAlquileres.txt");
            Console.WriteLine("Archivo ' reporteAlquileres.txt' exportado con éxito.");
        }
    }
}