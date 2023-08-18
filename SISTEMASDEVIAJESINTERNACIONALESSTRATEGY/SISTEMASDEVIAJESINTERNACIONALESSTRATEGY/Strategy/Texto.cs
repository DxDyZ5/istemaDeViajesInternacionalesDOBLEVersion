using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorHotel;
using System.Text.Json;
using System.IO;
using System.Text;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Strategy
{
    class Texto : IFormato
    {
        public void formato(dynamic resultado)
        {
            string nombreArchivo = "Recibo_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", nombreArchivo);

            string texto = JsonSerializer.Serialize(resultado, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, texto);
        }   
    }
}
