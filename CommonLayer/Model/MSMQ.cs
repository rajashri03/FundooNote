namespace CommonLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using Experimental.System.Messaging;
    public class MSMQ
    {
        MessageQueue msg = new MessageQueue();
        public void sendmsg(string token)
        {
            msg.Path = @".\private$\Token";//for windows path
            if (!MessageQueue.Exists(msg.Path))
            {
                MessageQueue.Create(msg.Path);
            }
            msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });//for asyn communication
            msg.ReceiveCompleted += Msg_ReceiveCompleted;//delegates,press tab here
            msg.Send(token);
            msg.BeginReceive();
            msg.Close();
        }

        private void Msg_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                var message = msg.EndReceive(e.AsyncResult);
                string token = message.Body.ToString();
                string Subject = "Forget Password Token";
                string Body = $"Forget Your Password?\nTo Reset Your password copy this token and paste it\n\n"+token;
                string jwt= jwtToken(token);
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                     Credentials = new NetworkCredential("rajashri03telvekar@gmail.com", "Rajshri@1234"),//give dummy gmail
                    EnableSsl = true,
                };

                smtpClient.Send("rajashri03telvekar@gmail.com", jwt, Subject, Body);
                msg.BeginReceive();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string jwtToken(string token)
        {
            var decodedToken = token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken((decodedToken));
            var result = jsonToken.Claims.FirstOrDefault().Value;
            return result;
        }
    }
}
