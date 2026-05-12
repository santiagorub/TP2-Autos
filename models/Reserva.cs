using TP2Autos.Models;

namespace alquiler_de_autos.models
{
    public class Reserva
    {
         public Vehiculo vehiculo { get; set; }
         public Cliente cliente { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public Reserva(Vehiculo vehiculo, Cliente cliente, DateTime fechaDesde, DateTime fechaHasta)
        {
            this.vehiculo = vehiculo;
            this.cliente = cliente;
            this.FechaDesde = fechaDesde;
            this.FechaHasta = fechaHasta;
        }
    }
}