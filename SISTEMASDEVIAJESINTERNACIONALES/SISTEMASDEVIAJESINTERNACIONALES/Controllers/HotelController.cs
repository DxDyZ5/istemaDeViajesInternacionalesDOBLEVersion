using Microsoft.AspNetCore.Mvc;
using SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorHotel;
using SISTEMASDEVIAJESINTERNACIONALES.Fachada;

namespace SISTEMASDEVIAJESINTERNACIONALES.Controllers
{
    [ApiController]
    [Route("HotelControlador")]
    public class HotelController : ControllerBase
    {
        private ViajeFachada fachadaViaje;

        public HotelController()
        {
            fachadaViaje = new ViajeFachada();
        }

        [HttpGet]
        [Route("BusquedaHotel")]
        public IActionResult Buscar(string destino, DateTime fechaEntrada, DateTime fechaSalida)
        {
            var hoteles = fachadaViaje.BuscarHoteles(destino, fechaEntrada, fechaSalida);
            return Ok(hoteles);
        }

        [HttpPost]
        [Route("ReservaHotel")]
        public dynamic Reservar(int idHotel, Huesped huesped)
        {
            var reserva = fachadaViaje.ReservarHotel(idHotel, huesped);
            return Ok(reserva);
        }
    }
}
