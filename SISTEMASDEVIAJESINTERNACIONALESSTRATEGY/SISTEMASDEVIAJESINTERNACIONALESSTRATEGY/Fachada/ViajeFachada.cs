    using System;
using System.Collections.Generic;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorHotel;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorRentaCarros;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorVuelo;

namespace SISTEMASDEVIAJESINTERNACIONALES.Fachada
{
    public class ViajeFachada
    {
        private IGestorVuelo gestorVuelo;
        private IGestorHotel gestorHotel;
        private IGestorRentaCarro gestorRentaCarro;

        public ViajeFachada(IGestorVuelo gestorVuelo, IGestorHotel gestorHotel, IGestorRentaCarro gestorRentaCarro)
        {
            this.gestorVuelo = gestorVuelo;
            this.gestorHotel = gestorHotel;
            this.gestorRentaCarro = gestorRentaCarro;
        }

        public List<Vuelo> BuscarVuelos(string origen, string destino, DateTime FechaSalida, DateTime FechaRegreso)
        {
            return gestorVuelo.BuscarVuelo(origen, destino, FechaSalida, FechaRegreso);
        }

        public dynamic ReservarVuelo(int idVuelo, Pasajero pasajero, string FormatoInfo)
        {
            return gestorVuelo.ReservarVuelo(idVuelo, pasajero, FormatoInfo);
        }

        public List<Hotel> BuscarHoteles(string destino, DateTime fechaEntrada, DateTime fechaSalida)
        {
            return gestorHotel.BuscarHoteles(destino, fechaEntrada, fechaSalida);
        }

        public dynamic ReservarHotel(int idHotel, Huesped huesped, string FormatoInfo)
        {
            return gestorHotel.ReservaHotel(idHotel, huesped, FormatoInfo);
        }

        public List<RentaCarro> BuscarRentasDeCarro(string destino, DateTime fechaInicio, DateTime fechaFin)
        {
            return gestorRentaCarro.BuscarRentaCarros(destino, fechaInicio, fechaFin);
        }

        public dynamic RentarCarro(int idCarro, Rentador rentador, string FormatoInfo)
        {
            return gestorRentaCarro.RentarCarro(idCarro, rentador, FormatoInfo);
        }
    }
}


