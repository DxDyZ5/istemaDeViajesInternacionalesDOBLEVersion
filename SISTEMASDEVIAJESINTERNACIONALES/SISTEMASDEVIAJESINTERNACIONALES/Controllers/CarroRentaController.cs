using Microsoft.AspNetCore.Mvc;
using SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorRentaCarros;
using SISTEMASDEVIAJESINTERNACIONALES.Fachada;

namespace SISTEMASDEVIAJESINTERNACIONALES.Controllers
{

    [ApiController]
    [Route("CarroControlador")]
    public class CarroRentaController : ControllerBase
    {
        private ViajeFachada fachadaViaje;

        public CarroRentaController()
        {
            fachadaViaje = new ViajeFachada();
        }

        [HttpGet]
        [Route("BusquedaCarro")]
        public IActionResult Buscar(string destino, DateTime fechaInicio, DateTime fechaFin)
        {
            var rentasCarros = fachadaViaje.BuscarRentasDeCarro(destino, fechaInicio, fechaFin);
            return Ok(rentasCarros);
        }
          
        [HttpPost]
        [Route("ReservaCarro")]
        public dynamic Rentar(int idCarro, Rentador rentador)
        {
          var renta =  fachadaViaje.RentarCarro(idCarro, rentador);
            return Ok(renta);
        }
    }
}
