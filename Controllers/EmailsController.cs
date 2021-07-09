using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using HoteldeMascotas.Models;
using HoteldeMascotas.Data;

namespace HoteldeMascotas.Controllers
{
    public class EmailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> IndexMail()
        {
            return View(await _context.Mails.ToListAsync());
        }

        
        public IActionResult Index2()
        {
            return View();
        }
        

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index2([Bind("id, Por, Para, Asunto , Mensaje")] Emails emailObject)
        {

            MailMessage Email = new MailMessage();

            Email.From = new MailAddress(emailObject.Para, "HotelMascotasCorreo", System.Text.Encoding.UTF8);
            Email.To.Add("hibarilaloski@gmail.com");
            Email.Subject = "Solicito contacto";
            Email.Body = emailObject.Mensaje;
            Email.IsBodyHtml = true;
            Email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("hibarilaloski@gmail.com", "lalo90377347");
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;

            smtp.Send(Email);
            smtp.Dispose();


            if (ModelState.IsValid)
            {
                emailObject.Para = "hibarilaloski@gmail.com";
                _context.Add(emailObject);
                await _context.SaveChangesAsync();
                return RedirectToAction();
            }

            return View(emailObject);

        }

    }
}