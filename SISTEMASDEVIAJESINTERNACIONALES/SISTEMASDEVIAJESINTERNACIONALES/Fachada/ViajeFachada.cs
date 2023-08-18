using System;
using System.Collections.Generic;
using SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorHotel;
using SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorRentaCarros;
using SISTEMASDEVIAJESINTERNACIONALES.ClasesGestorVuelo;

namespace SISTEMASDEVIAJESINTERNACIONALES.Fachada
{
    public class ViajeFachada
    {
        private GestorVuelo gestorVuelo;
        private GestorHotel gestorHotel;
        private GestorRentaCarro gestorRentaCarro;

        public ViajeFachada()
        {
            gestorVuelo = new GestorVuelo();
            gestorHotel = new GestorHotel();
            gestorRentaCarro = new GestorRentaCarro();
        }

        public List<Vuelo> BuscarVuelos(string origen, string destino, DateTime FechaSalida, DateTime FechaRegreso)
        {
            return gestorVuelo.BuscarVuelo(origen, destino, FechaSalida, FechaRegreso);
        }

        public dynamic ReservarVuelo(int idVuelo, Pasajero pasajero)
        {
           return gestorVuelo.ReservarVuelo(idVuelo, pasajero);
        }

        public List<Hotel> BuscarHoteles(string destino, DateTime fechaEntrada, DateTime fechaSalida)
        {
            return gestorHotel.BuscarHoteles(destino, fechaEntrada, fechaSalida);
        }

        public dynamic ReservarHotel(int idHotel, Huesped huesped)
        {
           return gestorHotel.ReservaHotel(idHotel, huesped);
        }

        public List<RentaCarro> BuscarRentasDeCarro(string destino, DateTime fechaInicio, DateTime fechaFin)
        {
            return gestorRentaCarro.BuscarRentaCarros(destino, fechaInicio, fechaFin);
        }

        public dynamic RentarCarro(int idCarro, Rentador rentador)
        {
            return gestorRentaCarro.RentarCarro(idCarro, rentador);
        }
    }
}


