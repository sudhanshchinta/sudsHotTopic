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

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "relay-hosting.secureserver.net";
            client.EnableSsl = true;
            //client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("sudhanshchintacompany@gmail.com", "Qwerty1234!");

            MailMessage mail = new MailMessage("donotreply@sudsweb.com", "sudhanshchintacompany@gmail.com", "Inquiry - Need Website",$"Name:{data.name}\n Email:{data.email}\n Phone:{data.phone}\n Message:{data.message}");

            client.Send(mail);

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