namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorHotel
{
    public interface IGestorHotel
    {
        public List<Hotel> BuscarHoteles(string destino, DateTime fechaEntrada, DateTime fechaSalida);

        public dynamic ReservaHotel(int hotelId, Huesped huesped, string FormatoInfo);
    }
}
