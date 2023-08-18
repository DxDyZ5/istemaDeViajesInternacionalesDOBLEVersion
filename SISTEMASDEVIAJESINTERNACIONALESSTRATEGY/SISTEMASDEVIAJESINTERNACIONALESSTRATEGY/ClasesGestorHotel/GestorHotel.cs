using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Observer;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Strategy;
using System.Text.Json;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorHotel
{
    public class GestorHotel : IGestorHotel
    {
        public List<Hotel> BuscarHoteles(string destino, DateTime fechaEntrada, DateTime fechaSalida)
        {
            string jsonContent = File.ReadAllText("./ClasesGestorHotel/HotelDatos.json");
            List<Hotel> hotel = JsonSerializer.Deserialize<List<Hotel>>(jsonContent);
            List<Hotel> hotelesEncontrados = hotel.Where(hotel => hotel.Ubicacion.Contains(destino, StringComparison.OrdinalIgnoreCase)).ToList();
            return hotelesEncontrados;
        }

        public dynamic ReservaHotel(int hotelId, Huesped huesped, string FormatoInfo)
        {
            string jsonContent = File.ReadAllText("./ClasesGestorHotel/HotelDatos.json");
            List<Hotel> hoteles = JsonSerializer.Deserialize<List<Hotel>>(jsonContent);

            if (hotelId != 1)
            {
                throw new ArgumentException("No existe dicho hotel");
            }
            
            List<Hotel> hotelesEncontrados = hoteles.Where(hotel => hotel.IDhotel == hotelId).ToList();

            dynamic resultado = new
            {
                Hotel = hotelesEncontrados,
                Huesped = huesped
            };


            Contexto contexto = new Contexto(FabricadorDeFormato.GetFormato(FormatoInfo));
            contexto.Formato(resultado);
            return resultado;
        }
    }
}
