using CoreEticaret.Identity;
using CoreEticaret.Models;
using CoreEticaret.Repositories.Abstract;
using CoreEticaret.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEticaret.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        private IEmailService _emailService;
        private readonly IConfiguration _configuration;

        private readonly IAccountRepository _accountRepository;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserService userService, IEmailService emailService, IConfiguration configuration, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
            _accountRepository = accountRepository;
        }

        //[Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        //[Route("signup")]
        //[HttpPost]
        //public async Task<IActionResult> Signup(SignUpUserModel userModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // write your code
        //        var user = new ApplicationUser
        //        {
        //            FirstName = userModel.FirstName,
        //            LastName = userModel.LastName,
        //            Email = userModel.Email,
        //            UserName = userModel.Email
        //        };

        //        var result = await _userManager.CreateAsync(user, userModel.Password);
        //        if (result.Succeeded)
        //        {
        //            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //            if (!string.IsNullOrEmpty(token))
        //            {
        //                string appDomain = _configuration.GetSection("Application:AppDomain").Value;
        //                string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;

        //                UserEmailOptions options = new UserEmailOptions
        //                {
        //                    ToEmails = new List<string>() { user.Email },
        //                    PlaceHolders = new List<KeyValuePair<string, string>>()
        //                    {
        //                        new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
        //                        new KeyValuePair<string, string>("{{Link}}",
        //                        string.Format(appDomain + confirmationLink, user.Id, token))
        //                    }
        //                };

        //                await _emailService.SendEmailForEmailConfirmation(options);
        //            }
        //        }
        //        if (!result.Succeeded)
        //        {
        //            foreach (var errorMessage in result.Errors)
        //            {
        //                ModelState.AddModelError("", errorMessage.Description);
        //            }

        //            return View(userModel);
        //        }

        //        ModelState.Clear();

        //        return RedirectToAction("ConfirmEmail", new { email = userModel.Email });
        //    }

        //    return View(userModel);
        //}

        //[Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                // write your code
                var result = await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(userModel);
                }

                ModelState.Clear();
                return RedirectToAction("ConfirmEmail", new { email = userModel.Email });
            }

            return View(userModel);
        }

        //[Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        //[Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(signInModel.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Bu e-mail adresi ile daha önce hesap oluşturulmamış.");

                    return View(signInModel);
                }
                
                var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Not allowed to login");
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Account blocked. Try after some time.");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid credentials");
                }

            }

            return View(signInModel);
        }

        //[Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        //[Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //[HttpPost("change-password")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userService.GetUserId();
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();

                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        //[HttpGet("confirm-email")]
        //public async Task<IActionResult> ConfirmEmail(string uid, string token, string email)
        //{
        //    EmailConfirmModel model = new EmailConfirmModel
        //    {
        //        Email = email
        //    };

        //    if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
        //    {
        //        token = token.Replace(' ', '+');
        //        var result = await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
        //        if (result.Succeeded)
        //        {
        //            model.EmailVerified = true;
        //        }
        //    }

        //    return View(model);
        //}


        //[HttpPost("confirm-email")]
        //[HttpPost]
        //public async Task<IActionResult> ConfirmEmail(EmailConfirmModel model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user != null)
        //    {
        //        if (user.EmailConfirmed)
        //        {
        //            model.EmailVerified = true;

        //            return View(model);
        //        }

        //        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //        if (!string.IsNullOrEmpty(token))
        //        {
        //            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
        //            string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;

        //            UserEmailOptions options = new UserEmailOptions
        //            {
        //                ToEmails = new List<string>() { user.Email },
        //                PlaceHolders = new List<KeyValuePair<string, string>>()
        //                {
        //                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
        //                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token))
        //                }
        //            };

        //            await _emailService.SendEmailForEmailConfirmation(options);
        //        }

        //        model.EmailSent = true;
        //        ModelState.Clear();
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Something went wrong.");
        //    }

        //    return View(model);
        //}

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string uid, string token, string email)
        {
            EmailConfirmModel model = new EmailConfirmModel
            {
                Email = email
            };

            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var result = await _accountRepository.ConfirmEmailAsync(uid, token);
                if (result.Succeeded)
                {
                    model.EmailVerified = true;
                }
            }

            return View(model);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(EmailConfirmModel model)
        {
            var user = await _accountRepository.GetUserByEmailAsync(model.Email);
            if (user != null)
            {
                if (user.EmailConfirmed)
                {
                    model.EmailVerified = true;
                    return View(model);
                }

                await _accountRepository.GenerateEmailConfirmationTokenAsync(user);
                model.EmailSent = true;
                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong.");
            }

            return View(model);
        }

        //[AllowAnonymous]
        [HttpGet("fotgot-password")]
        //[HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //[AllowAnonymous, HttpPost("fotgot-password")]
        [HttpPost("fotgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                // code here
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    if (!string.IsNullOrEmpty(token))
                    {
                        string appDomain = _configuration.GetSection("Application:AppDomain").Value;
                        string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;

                        UserEmailOptions options = new UserEmailOptions
                        {
                            ToEmails = new List<string>() { user.Email },
                            PlaceHolders = new List<KeyValuePair<string, string>>()
                            {
                                new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                                new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token))
                            }
                        };

                        await _emailService.SendEmailForForgotPassword(options);
                    }
                }

                ModelState.Clear();
                model.EmailSent = true;
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                //FullName = model.FullName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // generate token
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                //{
                //    userId = user.Id,
                //    token = code
                //});

                // send email
                //await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Onaylayınız.", $"Lütfen hesabınızı onaylamak icin linke <a href='http://localhost:498847{callbackUrl}'tıklayınız.</a>");

                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu lütfen tekrar deneyiniz.");

            return View(model);
        }

        //public IActionResult Login(string ReturnURL = null)
        //{
        //    return View(new LoginModel()
        //    {
        //        ReturnURL = ReturnURL
        //    });
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = await _userManager.FindByEmailAsync(model.Email);

        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "Bu e-mail adresi ile daha önce hesap oluşturulmamış.");

        //        return View(model);
        //    }

        //    if (!await _userManager.IsEmailConfirmedAsync(user))
        //    {
        //        ModelState.AddModelError("", "Lutfen hesabınızı e-mail adresiniz ile onaylayınız.");

        //        return View(model);
        //    }

        //    var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

        //    if (result.Succeeded)
        //    {
        //        return Redirect(model.ReturnURL ?? "~/");
        //    }

        //    ModelState.AddModelError("", "E-mail adresi ve ya parola yanlış");

        //    return View(model);
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();

        //    return Redirect("~/");
        //}

        //public async Task<IActionResult> ConfirmEmail(string userId, string token)
        //{
        //    if (userId == null || token == null)
        //    {
        //        TempData["message"] = "Gecersiz token.";

        //        return View();
        //    }

        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        TempData["message"] = "Böyle bir hesap bulunamadı.";

        //        return View();
        //    }

        //    var result = await _userManager.ConfirmEmailAsync(user, token);
        //    if (result.Succeeded)
        //    {
        //        TempData["message"] = "Hesabınız onaylandı.";

        //        return View();
        //    }

        //    TempData["message"] = "Hesabınız onaylanmadı.";

        //    return View();
        //}

        //[HttpGet]
        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ForgotPassword(string email)
        //{
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        return View();
        //    }

        //    var user = await _userManager.FindByEmailAsync(email);

        //    if (user == null)
        //    {
        //        return View();
        //    }

        //    var code = await _userManager.GeneratePasswordResetTokenAsync(user);

        //    var callbackUrl = Url.Action("RessetPassword", "Account", new
        //    {
        //        userId = user.Id,
        //        token = code
        //    });

        //    // send email
        //    //await _emailSender.SendEmailAsync(email, "Resset Password", $"Sifrenizi yenilek icin linke <a href='http://localhost:49884{callbackUrl}'tıklayınız.</a>");

        //    return RedirectToAction("Login", "Account");
        //}

        [AllowAnonymous, HttpGet("reset-password")]
        public IActionResult ResetPassword(string uid, string token)
        {
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel
            {
                Token = token,
                UserId = uid
            };

            return View(resetPasswordModel);
        }

        [AllowAnonymous, HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if ( (model.NewPassword != null) && (model.NewPassword == model.ConfirmNewPassword))
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    model.Token = model.Token.Replace(' ', '+');
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                    if (result.Succeeded)
                    {
                        model.IsSuccess = true;
                        ModelState.Clear();

                        if (!string.IsNullOrEmpty(model.Token))
                        {
                            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
                            string loginLink = _configuration.GetSection("Application:Login").Value;
                            string link = string.Concat(appDomain, loginLink);

                            UserEmailOptions options = new UserEmailOptions
                            {
                                ToEmails = new List<string>() { user.Email },
                                PlaceHolders = new List<KeyValuePair<string, string>>()
                                {
                                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                                    new KeyValuePair<string, string>("{{Link}}", link)
                                    //new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + loginLink, user.Id, model.Token))
                                }
                            };

                            await _emailService.SendEmailResetPassword(options);
                        }
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }                
            }
            else
            {
                return View(model);
            }
            
          
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    model.Token = model.Token.Replace(' ', '+');
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                    if (result.Succeeded)
                    {
                        ModelState.Clear();

                        return View(model);
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }

        //[AllowAnonymous, HttpPost("reset-password")]
        ////[HttpPost("reset-password")]
        //public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        //{
        //    //var user = await _userManager.FindByIdAsync(model.UserId);
        //    //if (user == null)
        //    //{
        //    //    return RedirectToAction("Home", "Index");
        //    //}

        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user != null)
        //        {
        //            model.Token = model.Token.Replace(' ', '+');
        //            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                return View("ResetPasswordConfirmation");
        //            }
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //            return View(model);
        //        }
        //        return View("ResetPasswordConfirmation");
        //    }
        //    return View(model);
        //    //        model.Token = model.Token.Replace(' ', '+');
        //    //    var result = await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
        //    //    if (result.Succeeded)
        //    //    {
        //    //        var user = await _userManager.FindByIdAsync(model.UserId);
        //    //        if (user != null)
        //    //        {
        //    //            var token = model.Token;
        //    //            if (!string.IsNullOrEmpty(token))
        //    //            {
        //    //                string appDomain = _configuration.GetSection("Application:AppDomain").Value;
        //    //                string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;

        //    //                UserEmailOptions options = new UserEmailOptions
        //    //                {
        //    //                    ToEmails = new List<string>() { user.Email },
        //    //                    PlaceHolders = new List<KeyValuePair<string, string>>()
        //    //                    {
        //    //                        new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
        //    //                        new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token))
        //    //                    }
        //    //                };

        //    //                await _emailService.SendEmailResetPassword(options);
        //    //            }
        //    //        }

        //    //        ModelState.Clear();
        //    //        model.IsSuccess = true;

        //    //        return View(model);
        //    //    }

        //    //    foreach (var error in result.Errors)
        //    //    {
        //    //        ModelState.AddModelError("", error.Description);
        //    //    }
        //    //}

        //    //return View(model);
        //}
    }
}
