using Microsoft.AspNetCore.Mvc;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorHotel;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorRentaCarros;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorVuelo;
using System.Text.Json;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Observer
{
    public class gestorObserver
    {

        private static gestorObserver _instance;

        private gestorObserver()
        {

        }
        public static gestorObserver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new gestorObserver();
                }
                return _instance;
            }
        }
        public void OperacionesObserver()
        {
            Hotel hotel = Hotel.Instance;
            string jsonContent = File.ReadAllText("./ClasesGestorRentaCarros/CarrosRentaDatos.json");
            List<RentaCarro> carros = JsonSerializer.Deserialize<List<RentaCarro>>(jsonContent);

            foreach (var carro in carros)
            {
                RentaCarro rentACar = new RentaCarro
                {
                    CarroId = carro.CarroId,
                    Marca = carro.Marca,
                    Modelo = carro.Modelo,
                    Anio = carro.Anio,
                    Tipo = carro.Tipo,
                    CapacidadPasajeros = carro.CapacidadPasajeros,
                    Transmision = carro.Transmision,
                    PrecioPorDia = carro.PrecioPorDia,  
                    Ubicacion = carro.Ubicacion
                };
                hotel.agregarSUB(rentACar); 
            }

        }

        public dynamic mostrar()
        {
            string jsonContent = File.ReadAllText("./Observer/ClienteDatos.json");
            List<Cliente> clientes = JsonSerializer.Deserialize<List<Cliente>>(jsonContent);
            return clientes;
        }


     
    }
}

