using Microsoft.AspNetCore.Mvc;
using SISTEMASDEVIAJESINTERNACIONALES.Fachada;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorHotel;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Controllers
{

    [ApiController]
    [Route("HotelControlador")]
    public class HotelController : ControllerBase
    {

        private ViajeFachada fachadaViaje;

        public HotelController(IGestorHotel gestorHotel)
        {
            fachadaViaje = new ViajeFachada(null, gestorHotel, null);
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
        public dynamic Reservar(int idHotel, Huesped huesped, string FormatoInfo)
        {
            var reserva = fachadaViaje.ReservarHotel(idHotel, huesped, FormatoInfo);
            return Ok(reserva);
        }
    }
}
