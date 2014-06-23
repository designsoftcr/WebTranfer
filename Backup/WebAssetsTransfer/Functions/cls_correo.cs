using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
namespace WebAssetsTransfer.Functions
{
    public class cls_correo
    {
        public bool enviar_correo(string to, string body, bool format_html, string subject, string from, string host, int port, string password, bool SSL)
        {
            bool result;
            try
            {
                SmtpClient smtp = new SmtpClient();
                if (port != 0)
                {
                    smtp.Port = port;
                }
                smtp.Host = host;
                smtp.EnableSsl = SSL;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.Timeout = 20000;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(from);
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailMessage.Body, null, "text/html");
                LinkedResource image_resource_header = new LinkedResource(HttpContext.Current.Server.MapPath("../Images/bg_header_mail.jpg"), "image/jpeg");
                image_resource_header.ContentId = "img_header";
                image_resource_header.TransferEncoding = TransferEncoding.Base64;
                htmlView.LinkedResources.Add(image_resource_header);
                LinkedResource image_resource_line = new LinkedResource(HttpContext.Current.Server.MapPath("../Images/line_up_mail.jpg"), "image/jpeg");
                image_resource_line.ContentId = "line_up_mail";
                image_resource_line.TransferEncoding = TransferEncoding.Base64;
                htmlView.LinkedResources.Add(image_resource_line);
                LinkedResource image_resource_bg_content_mail = new LinkedResource(HttpContext.Current.Server.MapPath("../Images/bg_content_right_mail.jpg"), "image/jpeg");
                image_resource_bg_content_mail.ContentId = "bg_content_mail";
                image_resource_bg_content_mail.TransferEncoding = TransferEncoding.Base64;
                htmlView.LinkedResources.Add(image_resource_bg_content_mail);
                mailMessage.AlternateViews.Add(htmlView);
                mailMessage.IsBodyHtml = format_html;
                smtp.Send(mailMessage);
                result = true;
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }
    }
}
