namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Strategy
{
    class FabricadorDeFormato
    {
        public static IFormato GetFormato(string formatoinfo)
        {
            if (formatoinfo.ToLower() == "json")
            {
                return new Json();
            }
            else if (formatoinfo.ToLower() == "texto")
            {
                return new Texto();
            }
            else if (formatoinfo.ToLower() == "excel")
            {
                return new Excel();
            }
            else
            {
                 throw new ArgumentException("No se puede este formato, por favor intenta escribir los siguientes: json, texto, excel");
            }
        }
    }
}
