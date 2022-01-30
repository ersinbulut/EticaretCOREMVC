using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Pay
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Lütfen Kart Numarası Giriniz..")]
        //[RegularExpression(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$", ErrorMessage = "Geçersiz Kart Numarası")]//visa için
        //[DisplayName("Kart Numarası")]
        public string CartNumber { get; set; }
        //[Required(ErrorMessage = "Lütfen Güvenlik Numarası Giriniz..")]
        //[RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Geçersiz Güvenlik Numarası")]
        //[DisplayName("Güvenlik Numarası")]
        public string SecurityNumber { get; set; }
        //[Required(ErrorMessage = "Lütfen Kart Sahibinin Adını Giriniz..")]
        //[DisplayName("Kart Üzerindeki İsim")]
        public string CartHasName { get; set; }
        //[Required(ErrorMessage = "Lütfen Son Kullanma Yıl Giriniz..")]
        //[RegularExpression(@"\d{4}$", ErrorMessage = "Geçersiz Yıl Bilgisi")]
        //[DisplayName("Son Kullanma Yıl")]
        public int ExpYear { get; set; }
        //[Required(ErrorMessage = "Lütfen Son Kullanma Ay Giriniz..")]
        //[RegularExpression(@"^[0-9]{1,2}", ErrorMessage = "Geçersiz Ay Bilgisi")]
        //[DisplayName("Son Kullanma Ay")]
        public int ExpMonth { get; set; }

        public int AddressID { get; set; }
        public virtual Addres Addres { get; set; }
    }
}
