using System.Net.Mail;
using System.Net;

namespace AppWeb24CVcopia.Services
{
    public class EmailServices : IEmailServices
    {
        public bool SendEmail(string email, string comentario)
        {

            bool result = false;

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("mail.shapp.mx", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");
                mail.From = new MailAddress("moises.puc@shapp.mx", "Administrador");
                mail.To.Add(email);
                mail.Subject = "Notificación de contacto";
                mail.IsBodyHtml = true;
                mail.Body = $"Se ha recibido información del correo <h1>{email} </h1> <br/> <p>{comentario}<p>";
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al enviar el correo", ex);
            }
        }
        
           
        

     
        
        
    }
}
