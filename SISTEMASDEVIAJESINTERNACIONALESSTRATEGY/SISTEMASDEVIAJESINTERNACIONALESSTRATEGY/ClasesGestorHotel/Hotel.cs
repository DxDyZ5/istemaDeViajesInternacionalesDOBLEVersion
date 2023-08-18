using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Observer;


namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorHotel
{
    public class Hotel
    {

        private static Hotel _instance;

        public int IDhotel { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public bool Disponibilidad { get; set; }

        private List<Iobservador> _observadores = new List<Iobservador>();

        private int _cuposDisponibles = 10;


        public Hotel(int iDhotel, string nombre, string ubicacion, bool disponibilidad)
        {
            IDhotel = iDhotel;
            Nombre = nombre;
            Ubicacion = ubicacion;
            Disponibilidad = disponibilidad;
        }

        private Hotel()
        {
            //instancia privada 
        }
        public static Hotel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Hotel();
                }
                return _instance;
            }
        }


        public bool agregarSUB(Iobservador observador)
        {
            _observadores.Add(observador);

            if (observador is Cliente)
            {
                _cuposDisponibles--;
            }

            Notificar();

            return _cuposDisponibles > 0; 
        }

        public void quitarSUB(Cliente cliente)
        {
            var clienteAEliminar = _observadores.FirstOrDefault(obs => obs is Cliente c && c.Nombre == cliente.Nombre && c.Apellido == cliente.Apellido);

            if (clienteAEliminar != null)
            {
                _observadores.Remove(clienteAEliminar);

                if (cliente is Cliente) 
                {
                    _cuposDisponibles++;    
                }

                Notificar();
            }
        }
        private void Notificar()    
        {
            var observadoresACopiar = new List<Iobservador>(_observadores);
            foreach (var observador in observadoresACopiar)
            {
                observador.actualizar(_cuposDisponibles);
            }
        }
    }
}
