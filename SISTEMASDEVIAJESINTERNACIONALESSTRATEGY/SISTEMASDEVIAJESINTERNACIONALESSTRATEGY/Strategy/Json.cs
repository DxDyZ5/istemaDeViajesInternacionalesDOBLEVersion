using System.Text.Json;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Strategy
{
    class Json : IFormato
    {
        public void formato(dynamic resultado)
        {
            string nombreArchivo = "Recibo_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".json";
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", nombreArchivo);

            string json = JsonSerializer.Serialize(resultado, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, json);
        }
    }
}