using SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorVuelo;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;



namespace SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorHotel

{
    public class GestorHotel
    {
        public List<Hotel> BuscarHoteles(string destino, DateTime fechaEntrada, DateTime fechaSalida)
        {
        

            string jsonContent = File.ReadAllText("C:/Users/manue/source/repos/SISTEMASDEVIAJESINTERNACIONALES/SISTEMASDEVIAJESINTERNACIONALES/DATAJSON/HotelDatos.json");

            List<Hotel> hoteles = JsonSerializer.Deserialize<List<Hotel>>(jsonContent);


            List<Hotel> hotelesEncontrados = hoteles.Where(hotel => hotel.Ubicacion.Contains(destino, StringComparison.OrdinalIgnoreCase)).ToList();
            
            return hotelesEncontrados;
        }

        public dynamic ReservaHotel(int hotelId, Huesped huesped)
        {

            string jsonContent = File.ReadAllText("C:/Users/manue/source/repos/SISTEMASDEVIAJESINTERNACIONALES/SISTEMASDEVIAJESINTERNACIONALES/DATAJSON/HotelDatos.json");
            
            List<Hotel> hoteles = JsonSerializer.Deserialize<List<Hotel>>(jsonContent);


            if (hotelId < 1)
            {
                throw new Exception("No existe dicho hotel");
            }
            else if (hotelId > 5)
            {
                throw new Exception("No existe dicho hotel");
            }

            List<Hotel> hotelesEncontrados = hoteles.Where(hotel => hotel.IDhotel == hotelId).ToList();

            dynamic resultado = new
            {
                Hotel = hotelesEncontrados,
                Huesped = huesped,

            };

            
            
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "reserva.json");

                string contenidoJSON = JsonSerializer.Serialize(resultado, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(rutaArchivo, contenidoJSON);
            


            return resultado;
        }
    }
}

