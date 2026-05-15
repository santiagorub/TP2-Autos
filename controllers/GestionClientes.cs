using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.IO;   // Para StreamWriter
using System.Linq;
using alquiler_de_autos.models;

namespace alquiler_de_autos.controllers
{
    public class GestionClientes
    {
        private List<Cliente> clientes = new List<Cliente>();
        private string rutaArchivo = "clientes_exportados.csv";

        //para agregar un cliente nuevo
        public bool AgregarCliente(string dni, string nombre, string apellido, string email)
        {
            // datos que si o si precisamos
            if (string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                Console.WriteLine("Error: DNI, Nombre y Apellido son obligatorios.");
                return false;
            }

            // con esto validas el DNI para que no se repita
            if (clientes.Any(c => c.DNI == dni))
            {
                Console.WriteLine("Error: Ya existe un cliente con ese DNI.");
                return false;
            }

            clientes.Add(new Cliente { DNI = dni, Nombre = nombre, Apellido = apellido, Email = email });
            return true;
        }

        // el listado de clientes
        public void ListarClientes()
        {
            if (clientes.Count == 0) Console.WriteLine("No hay clientes registrados.");
            else clientes.ForEach(c => Console.WriteLine(c.ToString()));
        }

        // para exportar a un archivo de texto
        public void ExportarAArchivo()
        {
            try
            {
                string nombreCarpeta = "exports";
                if (!Directory.Exists(nombreCarpeta))  
                {
                    Directory.CreateDirectory(nombreCarpeta);
                }

                using (StreamWriter writer = new StreamWriter("exports/clientes_exportados.csv"))
                {
                    writer.WriteLine("DNI;Nombre;Apellido;Email");

                    foreach (var c in clientes)
                    {
                        writer.WriteLine($"{c.DNI};{c.Nombre};{c.Apellido};{c.Email}");
                    }
                }
                Console.WriteLine($"\nÉxito: Datos exportados a exports/clientes_exportados.csv");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al exportar: " + ex.Message);
            }
        }

        public Cliente BuscarPorDNI(string dni)
        {
            return clientes.Find(c => c.DNI == dni);
        }
        
    }
}