using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEticaret.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your subject")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Required]
        public string Captcha { get; set; }
        public bool IsSuccess { get; internal set; }
    }
}
