using Microsoft.AspNetCore.Mvc;
using SISTEMASDEVIAJESINTERNACIONALES.Fachada;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorRentaCarros;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Controllers
{

    [ApiController]
    [Route("CarroControlador")]
    public class CarroRentaController : ControllerBase
    {
        private ViajeFachada fachadaViaje;


        public CarroRentaController(IGestorRentaCarro gestorRentaCarro)
        {
            fachadaViaje = new ViajeFachada(null, null, gestorRentaCarro);
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
        public dynamic Rentar(int idCarro, Rentador rentador, string FormatoInfo)
        {
            var renta = fachadaViaje.RentarCarro(idCarro, rentador, FormatoInfo);
            return Ok(renta);
        }
    }
}
