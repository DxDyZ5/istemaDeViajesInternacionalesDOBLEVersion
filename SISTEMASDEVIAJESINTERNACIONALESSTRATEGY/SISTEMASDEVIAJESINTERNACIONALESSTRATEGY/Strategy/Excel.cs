using ClosedXML.Excel;
using System;
using System.IO;
using System.Text.Json;


namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Strategy
{
    class Excel : IFormato
    {
        public void formato(dynamic resultado)
        {
            string nombreArchivo = "Recibo_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", nombreArchivo);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Recibo");

                string json = JsonSerializer.Serialize(resultado, new JsonSerializerOptions { WriteIndented = true });

                worksheet.Cell(1, 1).Value = json;

                workbook.SaveAs(rutaArchivo);

            }
        }
    }
}
