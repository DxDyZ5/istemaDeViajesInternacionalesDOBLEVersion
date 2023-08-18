namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorVuelo
{
    public interface IGestorVuelo
    {
        public List<Vuelo> BuscarVuelo(string origen, string destino, DateTime FechaSalida, DateTime FechaRegreso);

        public dynamic ReservarVuelo(int idVuelo, Pasajero pasajero, string FormatoInfo);   
    }
}
