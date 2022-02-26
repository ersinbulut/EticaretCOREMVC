using CoreEticaret.Models;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CoreEticaret.Controllers
{
    public class ContactController : Controller
    {
        private readonly IDNTCaptchaValidatorService _validatorService;
        private readonly DNTCaptchaOptions _captchaOptions;
        private readonly SMTPConfigModel _smtpConfig;

        private string mailFrom;
        private string mailTo;
        private string mailSubject;
        private string mailBody;

        public ContactController(IDNTCaptchaValidatorService validatorService, IOptions<DNTCaptchaOptions> options, IOptions<SMTPConfigModel> smtpConfig)
        {
            _validatorService = validatorService;
            _captchaOptions = options == null ? throw new ArgumentNullException(nameof(options)) : options.Value;
            _smtpConfig = smtpConfig.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        //[Route("contactus")]
        [HttpPost]
        public async Task<IActionResult> Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_validatorService.HasRequestValidCaptchaEntry(Language.English, DisplayMode.ShowDigits))
                {
                    this.ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "Plase Enter Valid Captcha.");

                    return View(model);
                }
            }

            try
            {
                mailFrom = model.Email;
                mailTo = _smtpConfig.UserName;
                mailSubject = model.Subject;
                mailBody = "From : " + model.FullName;
                mailBody += "<br/> Mail : " + model.Email;
                mailBody += "<br/> Phone : " + model.Phone;
                mailBody += "<br/> Subject : " + model.Subject;
                mailBody += "<br/> Message : " + model.Message;

                SendEmail(mailFrom, _smtpConfig.UserName, mailSubject, mailBody);

                mailFrom = _smtpConfig.UserName;
                mailTo = model.Email;
                mailSubject = "Hello " + model.FullName + " Confirm your contact email.";
                mailBody = "Dear " + model.FullName + ", <br/> Thank you for emai.<br/> GH Global Team received your email regarding " + model.Subject + ". <br/> GH Global Team will be back to you as soon as possible.<br/><br/> Sincerely, GH Global Team<br/>Click on the following link to website.<br/><br/><a>www.coreticaret.com</a>";

                SendEmail(mailFrom, mailTo, mailSubject, mailBody);

                ModelState.Clear();
                ViewBag.IsSuccess = true;
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }

            return View();
        }

        private async Task SendEmail(string from, string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;

            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };

            mail.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mail);
        }
    }
}
