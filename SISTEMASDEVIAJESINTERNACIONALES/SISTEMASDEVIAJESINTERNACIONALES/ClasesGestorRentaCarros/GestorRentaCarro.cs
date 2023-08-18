   using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorRentaCarros
{
    public class GestorRentaCarro
    {
        public List<RentaCarro> BuscarRentaCarros(string destino, DateTime fechaInicio, DateTime fechaFin)
        {
            string jsonContent = File.ReadAllText("C:/Users/manue/source/repos/SISTEMASDEVIAJESINTERNACIONALES/SISTEMASDEVIAJESINTERNACIONALES/DATAJSON/CarrosRentaDatos.json");

            List<RentaCarro> carros = JsonSerializer.Deserialize<List<RentaCarro>>(jsonContent);

            List<RentaCarro> carrosEncontrados = carros.FindAll(carro => carro.Ubicacion.Contains(destino, StringComparison.OrdinalIgnoreCase));
            
            
         
            
            return carrosEncontrados;


            
        }

        public dynamic RentarCarro(int carroID, Rentador rentador)
        {
            string jsonContent = File.ReadAllText("C:/Users/manue/source/repos/SISTEMASDEVIAJESINTERNACIONALES/SISTEMASDEVIAJESINTERNACIONALES/DATAJSON/CarrosRentaDatos.json");

            List<RentaCarro> carros = JsonSerializer.Deserialize<List<RentaCarro>>(jsonContent);

            if (carroID < 1)
            {
                throw new Exception("No existe dicho carro");
            }
            else if (carroID > 5)
            {
                throw new Exception("No existe dicho carro");
            }

            List<RentaCarro> carroEncontrado = carros.Where(carro => carro.CarroId == carroID).ToList();

           
            dynamic resultado = new
            {
                Carro = carroEncontrado,
                Rentador = rentador,

            };
            
            

            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "Recibo.json");

            string contenidoJSON = JsonSerializer.Serialize(resultado, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(rutaArchivo, contenidoJSON);
            
            return resultado;
        }
    }
}

