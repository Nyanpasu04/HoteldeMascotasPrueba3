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

namespace TiendaRopaUsada_MVC.Controllers
{
    public class EmailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> IndexMail()
        {
            return View(await _context.Mails.ToListAsync());
        }

        [Authorize]
        public IActionResult IngresoMail()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IngresoMail([Bind("id, Por, Para, Asunto , Mensaje")] Emails emailObject)
        {

            MailMessage email = new MailMessage();

            email.From = new MailAddress(emailObject.Por, "HotelMascotasCorreo", System.Text.Encoding.UTF8);
            email.To.Add("hibarilaloski@gmail.com");
            email.Subject = "Solicito contacto";
            email.Body = emailObject.Mensaje;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("hibarilaloski@gmail.com", "lalo90377347");
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;

            smtp.Send(email);
            smtp.Dispose();


            if (ModelState.IsValid)
            {
                emailObject.Para = "j.acevedo.espindola@gmail.com";
                _context.Add(emailObject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexMail));
            }

            return View(emailObject);

        }

    }
}