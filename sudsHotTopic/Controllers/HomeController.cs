using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace sudsHotTopic.Controllers
{
    public class HomeController : Controller
    {

        public int MyProperty { get; set; }

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Mail(Message data)
        {

            MailMessage message = new MailMessage();
            message.From = new MailAddress("donotreply@sudsweb.com");
            message.To.Add(new MailAddress("sudhanshchintacompany@gmail.com"));
            message.Subject = "Inquiry - Need Website";
            message.Body = $"Name:{data.name}\n Email:{data.email}\n Phone:{data.phone}\n Message:{data.message}";

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "relay-hosting.secureserver.net";
            client.Send(message);

            return null;
        }

    }

    public class Message
    {

        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string message { get; set; }

    }

}