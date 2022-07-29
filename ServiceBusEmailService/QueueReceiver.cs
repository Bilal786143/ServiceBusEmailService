using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using ServiceBusEmailService.ViewModel;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ServiceBusEmailService
{
    public class QueueReceiver : ErrorHandler
    {
        public static async Task MessageReceiver(ProcessMessageEventArgs args)
        {
            string message = args.Message.Body.ToString();
            var sendMessageToCustomer = JsonConvert.DeserializeObject<OrderCreateRequest>(message);
            await args.CompleteMessageAsync(args.Message);
            //send mail
            string from = "meharrehan24525@gmail.com";
            string to = sendMessageToCustomer.Email;
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = "Order Placed Successfully";
            mail.Body = "<h2>MultiShop</h2><br/>Hi Mr/Mrs <b>" + sendMessageToCustomer.CustomerName + "</b> <br/>You have Successfully Placed an order on MultiShop.<br/>Your Order is on the way and May be delived to you in Two to Three Working Days";
            mail.IsBodyHtml = true;
            SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
            server.Credentials = new System.Net.NetworkCredential("meharrehan24525@gmail.com", "aoawozmujwxjjbok");
            server.EnableSsl = true;
            server.Send(mail);
        }
    }
}
