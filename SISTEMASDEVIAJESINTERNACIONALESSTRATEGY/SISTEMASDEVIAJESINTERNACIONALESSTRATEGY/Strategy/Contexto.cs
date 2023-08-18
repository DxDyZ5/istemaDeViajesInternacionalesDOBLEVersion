namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Strategy
{
    class Contexto
    {
        IFormato formatoInfo;

        public Contexto(IFormato formato)
        {
            this.formatoInfo = formato;
        }

        public void Formato(dynamic resultado)
        {
            formatoInfo.formato(resultado);
        }
    }
}
    