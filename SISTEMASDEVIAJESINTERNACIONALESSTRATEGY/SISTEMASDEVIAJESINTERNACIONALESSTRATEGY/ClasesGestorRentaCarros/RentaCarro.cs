using Newtonsoft.Json;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Observer;
using System.Net;
using System.Net.Mail;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorRentaCarros
{
    public class RentaCarro : Iobservador
    {
        public int CarroId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Tipo { get; set; }
        public int CapacidadPasajeros { get; set; }
        public string Transmision { get; set; }
        public decimal PrecioPorDia { get; set; }
        public string Ubicacion { get; set; }

        public void actualizar(int cuposDisponibles)
        {
            //Al cargar la el front actualiza y se agregan en el observador, los correos se envia en el cliente.
        }

        
    }
}
    