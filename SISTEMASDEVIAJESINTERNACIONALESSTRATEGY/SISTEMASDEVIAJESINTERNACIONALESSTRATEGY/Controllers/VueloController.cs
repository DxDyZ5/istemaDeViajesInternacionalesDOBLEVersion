using Microsoft.AspNetCore.Mvc;
using SISTEMASDEVIAJESINTERNACIONALES.Fachada;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorVuelo;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Controllers
{
    [ApiController]
    [Route("VueloControlador")]
    public class VueloController : ControllerBase
    {

        private ViajeFachada fachadaViaje;

        public VueloController(IGestorVuelo gestorVuelo)
        {
            fachadaViaje = new ViajeFachada(gestorVuelo, null, null);
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
        public dynamic Reservar(int idVuelo, Pasajero pasajero, string FormatoInfo)
        {
            var reserva = fachadaViaje.ReservarVuelo(idVuelo, pasajero, FormatoInfo);
            return Ok(reserva);
        }
    }
}
