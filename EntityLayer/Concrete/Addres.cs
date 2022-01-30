using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Addres
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Lütfen Adres Tanımını Giriniz..")]
        public string AdresBasligi { get; set; }
        //[Required(ErrorMessage = "Lütfen Adres Giriniz..")]
        public string Adres { get; set; }
        //[Required(ErrorMessage = "Lütfen İl Giriniz..")]
        public string Il { get; set; }
        //[Required(ErrorMessage = "Lütfen ilçe Giriniz..")]
        public string Ilce { get; set; }
        //[Required(ErrorMessage = "Lütfen Mahalle Giriniz..")]
        public string Mahalle { get; set; }
        //[Required(ErrorMessage = "Lütfen Posta Kodu Giriniz..")]
        public string PostaKodu { get; set; }
    }
}
