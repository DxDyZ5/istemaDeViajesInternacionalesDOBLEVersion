    using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Strategy;
using System.Text.Json;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;

namespace SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.Observer
{
    public class Cliente : Iobservador
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }


        public void actualizar(int cuposDisponibles) //Al enviar el correo dura un tiempo dele tiempo por favor
        {
 
            Cliente[] clientes = LeerClientesDesdeJson("./Observer/ClienteDatos.json");
   
            foreach (var cliente in clientes)
            {
                EnviarCorreo(cliente.Email, "Cupos Disponibles", $"¡Hola {cliente.Nombre} ! Los cupos disponibles son: {cuposDisponibles}");
            }
        }

        public void EnviarCorreo(string destino, string asunto, string cuerpo)
        {
            try
            {

                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587; 
                string correoEmisor = "manuel28604@gmail.com";
                string contrasenaEmisor = "pyeyrjgllvyxrwmn";

        
                MailMessage mensaje = new MailMessage(correoEmisor, destino);
                mensaje.Subject = asunto;
                mensaje.Body = cuerpo;
                mensaje.IsBodyHtml = false; 

              
                SmtpClient clienteSmtp = new SmtpClient(smtpHost, smtpPort);
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.EnableSsl = true;
                clienteSmtp.Credentials = new NetworkCredential(correoEmisor, contrasenaEmisor);

            
                clienteSmtp.Send(mensaje);

                Console.WriteLine($"Correo enviado correctamente a {destino}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo a {destino}: " + ex.Message);
            }
        }

        private static Cliente[] LeerClientesDesdeJson(string rutaArchivo)
        {
          
            string contenidoJson = File.ReadAllText(rutaArchivo);

           
            Cliente[] clientes = JsonConvert.DeserializeObject<Cliente[]>(contenidoJson);

            return clientes;
        }

    }
}


