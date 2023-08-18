using Microsoft.AspNetCore.Mvc;
using SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorVuelo;
using SISTEMASDEVIAJESINTERNACIONALES.Fachada;



namespace SISTEMASDEVIAJESINTERNACIONALES.Controllers
{
    [ApiController]
    [Route("VueloControlador")]
    public class VueloController : ControllerBase
    {
        private ViajeFachada fachadaViaje;

        public VueloController()
        {
            fachadaViaje = new ViajeFachada();
        }

        [HttpGet]
        [Route("BusquedaVuelo")]
        public IActionResult Buscar(string origen, string destino, DateTime FechaSalida, DateTime FechaRegreso)
        {
            var vuelos = fachadaViaje.BuscarVuelos(origen, destino, FechaSalida, FechaRegreso);
            return Ok(vuelos);
        }   

        [HttpPost]
        [Route("ReservaVuelo")]
        public dynamic Reservar(int idVuelo, Pasajero pasajero)
        {
           var reserva = fachadaViaje.ReservarVuelo(idVuelo, pasajero);
            return Ok(reserva);
        }
    }
}
