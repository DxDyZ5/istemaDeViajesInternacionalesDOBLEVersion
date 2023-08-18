using Microsoft.AspNetCore.Mvc;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorHotel;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Observer;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Controllers
{
    [ApiController]
    [Route("ClienteController")]

    public class ClienteController : ControllerBase
    {
        private gestorObserver observer;

        public ClienteController()
        {
            observer = gestorObserver.Instance;
        }

        [HttpGet]
        [Route("clienteobtener")]
        public dynamic obtener()
        {
            observer.OperacionesObserver();
            return observer.mostrar();
        }

        [HttpPost]
        [Route("clienteagregar")]
        public IActionResult agregar([FromBody] Cliente cliente)
        {
            Hotel hotel = Hotel.Instance;
            if (cliente != null)
            {
                if (hotel.agregarSUB(cliente))
                {
                    return Ok(new { message = $"Cliente {cliente.Nombre} {cliente.Apellido} ha sido agregado como suscriptor." });
                }
                else
                {
                    return BadRequest(new { message = "Se han acabado los cupos en el hotel, intente más tarde." });
                }
            }

            return BadRequest(new { message = "Los datos del cliente son inválidos." });
        }



        [HttpPost]
        [Route("clientequitar")]
        public IActionResult quitar([FromBody] Cliente cliente)
        {
            Hotel hotel = Hotel.Instance;
            if (cliente != null)
            {
                hotel.quitarSUB(cliente);
                return Ok(new { message = $"Cliente {cliente.Nombre} {cliente.Apellido} ha cancelado la suscripción." });
            }

            return BadRequest(new { message = "Los datos del cliente son inválidos." });
        }


    }
}
            


    