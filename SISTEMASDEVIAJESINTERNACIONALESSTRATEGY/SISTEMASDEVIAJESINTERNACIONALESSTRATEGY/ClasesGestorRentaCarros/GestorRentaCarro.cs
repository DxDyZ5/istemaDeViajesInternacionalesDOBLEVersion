using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorHotel;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorVuelo;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Strategy;
using System.Text.Json;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorRentaCarros
{
    public class GestorRentaCarro : IGestorRentaCarro
    {
        public List<RentaCarro> BuscarRentaCarros(string destino, DateTime fechaInicio, DateTime fechaFin)
        {
            string jsonContent = File.ReadAllText("./ClasesGestorRentaCarros/CarrosRentaDatos.json");
            List<RentaCarro> carros = JsonSerializer.Deserialize<List<RentaCarro>>(jsonContent);
            List<RentaCarro> carrosEncontrados = carros.Where(carro => carro.Ubicacion.Contains(destino, StringComparison.OrdinalIgnoreCase)).ToList();
            return carrosEncontrados;
        }


        public dynamic RentarCarro(int carroID, Rentador rentador, string FormatoInfo)
        {
            string jsonContent = File.ReadAllText("./ClasesGestorRentaCarros/CarrosRentaDatos.json");
            List<RentaCarro> carros = JsonSerializer.Deserialize<List<RentaCarro>>(jsonContent);

            if (carroID < 1 || carroID > 5)
            {
                throw new ArgumentException("No existe dicho carro");
            }

            List<RentaCarro> carroEncontrado = carros.Where(carro => carro.CarroId == carroID).ToList();

            dynamic resultado = new
            {
                Carro = carroEncontrado,
                Rentador = rentador
            };

            Contexto contexto = new Contexto(FabricadorDeFormato.GetFormato(FormatoInfo));
            contexto.Formato(resultado);

            return resultado;
        }
    }
}
