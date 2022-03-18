using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEticaret.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }


        public string Image { get; set; }

        public string ActivationCode { get; set; }//aktivasyon kodu

        /*Yeni Eklenen Alanlar*/
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }//dogum tarihi
        public string Gender { get; set; }//cinsiyet

        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public string CartNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string CartHasName { get; set; }
        public int ExpYear { get; set; }
        public int ExpMonth { get; set; }

      

        public virtual IEnumerable<Address> Address { get; set; }

        public virtual IEnumerable<Pay> Pays { get; set; }
    
    }
}
