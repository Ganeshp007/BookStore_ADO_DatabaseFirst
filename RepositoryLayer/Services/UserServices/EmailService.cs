﻿namespace RepositoryLayer.Services.UserServices
{
    using System.Net;
    using System.Net.Mail;

    public class EmailService
    {
        public static void SendEmail(string email, string token, string Firstname)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("gpotdar60@gmail.com", "njhccgdjptohsfkw");
                MailMessage msgObj = new MailMessage();
                msgObj.To.Add(email);
                msgObj.IsBodyHtml = true;
                msgObj.From = new MailAddress("gpotdar60@gmail.com");
                msgObj.Subject = "Password Reset Link";
                msgObj.Body = "<html><body><p><b>Hello " + $"{Firstname}" + "</b>,<br/>Please click the below link to Reset Your Password.<br/>" +
                   $"http://127.0.0.1:5500/Pages/User/ResetPassword.html/{token}" +
                   "<br/><br/><br/><b>Thanks&Regards </b><br/><b>Mail Team(donot - reply to this mail)</b></p></body></html>";
                client.Send(msgObj);
            }
        }
    }
}
