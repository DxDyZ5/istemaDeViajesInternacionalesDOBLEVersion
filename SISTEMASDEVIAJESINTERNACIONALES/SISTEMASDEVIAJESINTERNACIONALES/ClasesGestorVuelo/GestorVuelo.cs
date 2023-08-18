using SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorHotel;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorVuelo
{
    public class GestorVuelo
    {
        public List<Vuelo> BuscarVuelo(string origen, string destino, DateTime FechaSalida, DateTime FechaRegreso)
        {
           
            string jsonContent = File.ReadAllText("C:/Users/manue/source/repos/SISTEMASDEVIAJESINTERNACIONALES/SISTEMASDEVIAJESINTERNACIONALES/DATAJSON/VueloDatos.json");

            List<Vuelo> vuelos = JsonSerializer.Deserialize<List<Vuelo>>(jsonContent);

            List<Vuelo> vuelosEncontrados = vuelos.FindAll(Vuelo => Vuelo.Origen.Contains(origen, StringComparison.OrdinalIgnoreCase) || Vuelo.Destino.Contains(destino, StringComparison.OrdinalIgnoreCase) || Vuelo.FechaSalida == FechaSalida || Vuelo.FechaRegreso == FechaRegreso);

           
            return vuelosEncontrados;
        }

        public dynamic ReservarVuelo(int idVuelo, Pasajero pasajero)
        {

            string jsonContent = File.ReadAllText("C:/Users/manue/source/repos/SISTEMASDEVIAJESINTERNACIONALES/SISTEMASDEVIAJESINTERNACIONALES/DATAJSON/VueloDatos.json");

            List<Vuelo> vuelos = JsonSerializer.Deserialize<List<Vuelo>>(jsonContent);

            if (idVuelo < 1)
            {
                throw new Exception("No existe dicho vuelo");
            }
            else if(idVuelo > 5)
            {
                throw new Exception("No existe dicho vuelo");
            }
    

            List<Vuelo> vuelosEncontrados = vuelos.Where(vuelo => vuelo.IDvuelo == idVuelo).ToList();




            dynamic resultado = new
            {
                Vuelo = vuelosEncontrados,
                Pasajero = pasajero
            };



                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "ticket.json");

                string contenidoJSON = JsonSerializer.Serialize(resultado, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(rutaArchivo, contenidoJSON);


                return resultado;
        }
    }
}

