using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Strategy;
using System.Text.Json;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorVuelo
{
    public class GestorVuelo : IGestorVuelo
    {
        public List<Vuelo> BuscarVuelo(string origen, string destino, DateTime FechaSalida, DateTime FechaRegreso)
        {
            string jsonContent = File.ReadAllText("./ClasesGestorVuelo/VueloDatos.json");
            List<Vuelo> vuelos = JsonSerializer.Deserialize<List<Vuelo>>(jsonContent);
            List<Vuelo> vuelosEncontrados = vuelos.Where(Vuelo => Vuelo.Origen.Contains(origen, StringComparison.OrdinalIgnoreCase) || Vuelo.Destino.Contains(destino, StringComparison.OrdinalIgnoreCase) || Vuelo.FechaSalida == FechaSalida || Vuelo.FechaRegreso == FechaRegreso).ToList();
            return vuelosEncontrados;
        }

        public dynamic ReservarVuelo(int idVuelo, Pasajero pasajero, string FormatoInfo)
        {
            string jsonContent = File.ReadAllText("./ClasesGestorVuelo/VueloDatos.json");
            List<Vuelo> vuelos = JsonSerializer.Deserialize<List<Vuelo>>(jsonContent);

            if (idVuelo < 1 || idVuelo > 5)
            {
                throw new ArgumentException("No existe dicho vuelo");
            }

            List<Vuelo> vuelosEncontrados = vuelos.Where(vuelo => vuelo.IDvuelo == idVuelo).ToList();

            dynamic resultado = new
            {
                Vuelo = vuelosEncontrados,
                Pasajero = pasajero
            };

            Contexto contexto = new Contexto(FabricadorDeFormato.GetFormato(FormatoInfo));
            contexto.Formato(resultado);

            return resultado;
        }
    }
}
