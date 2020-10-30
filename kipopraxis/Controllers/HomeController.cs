using MailKit.Net.Smtp;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kipopraxis.Models;
using MimeKit;
using MimeKit.Text;
using System;

namespace kipopraxis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //instantiate a new MimeMessage
                    var message = new MimeMessage();
                    //Setting the To e-mail address
                    message.To.Add(new MailboxAddress("Kipopraxis Info", "info@kipopraxis.gr"));
                    //Setting the From e-mail address
                    message.From.Add(new MailboxAddress("Ιστοσελίδα kipopraxis.gr", "kipopraxis.gr@gmail.com"));
                    //E-mail subject 
                    message.Subject = contactViewModel.Subject;
                    //E-mail message body
                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = contactViewModel.Message + "<br /><br />Το μήνυμα εστάλη από: " + contactViewModel.Name + "<br />E-mail: " + contactViewModel.Email + "<br />Τηλέφωνο: " + contactViewModel.PhoneNumber
                    };

                    //Configure the e-mail
                    using (var emailClient = new SmtpClient())
                    {
                        emailClient.Connect("smtp.gmail.com", 587, false);
                        emailClient.Authenticate("kipopraxis.gr@gmail.com", "Kipopraxis123!@#");
                        emailClient.Send(message);
                        emailClient.Disconnect(true);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Ουπς! Κάποιο πρόβλημα υπάρχει εδώ! {ex.Message}";
                }
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Service1()
        {
            return View();
        }
        public IActionResult Service2()
        {
            return View();
        }
        public IActionResult Service3()
        {
            return View();
        }
        public IActionResult Service4()
        {
            return View();
        }
        public IActionResult Service5()
        {
            return View();
        }
        public IActionResult Service6()
        {
            return View();
        }
        public IActionResult Service7()
        {
            return View();
        }
        public IActionResult Service8()
        {
            return View();
        }
        public IActionResult Service9()
        {
            return View();
        }
        public IActionResult Service10()
        {
            return View();
        }
        public IActionResult Service11()
        {
            return View();
        }
        public IActionResult Service12()
        {
            return View();
        }
        public IActionResult Service13()
        {
            return View();
        }
        public IActionResult Service14()
        {
            return View();
        }
        public IActionResult Service15()
        {
            return View();
        }
        public IActionResult Service16()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
