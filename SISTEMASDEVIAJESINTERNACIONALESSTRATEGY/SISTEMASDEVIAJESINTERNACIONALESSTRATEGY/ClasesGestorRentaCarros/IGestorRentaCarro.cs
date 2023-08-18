namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorRentaCarros
{
    public interface IGestorRentaCarro
    {
        public List<RentaCarro> BuscarRentaCarros(string destino, DateTime fechaInicio, DateTime fechaFin);

        public dynamic RentarCarro(int carroID, Rentador rentador, string FormatoInfo);
    }
}
