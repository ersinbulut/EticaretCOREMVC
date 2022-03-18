using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreEticaret.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }//sipariş durumu

        public string UserName { get; set; }

        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public int UserAddressID { get; set; }
        public virtual Address UserAddress { get; set; }

        //public virtual List<Addres> Addres { get; set; }

        //*//*/

    
        public string CartNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Güvenlik Numarası Giriniz..")]
       
        public string SecurityNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Kart Sahibinin Adını Giriniz..")]
        public string CartHasName { get; set; }
        [Required(ErrorMessage = "Lütfen Son Kullanma Yıl Giriniz..")]
       
        public int ExpYear { get; set; }
        [Required(ErrorMessage = "Lütfen Son Kullanma Ay Giriniz..")]
       
        public int ExpMonth { get; set; }
        //*//*/

        public virtual List<OrderLineModel> OrderLines { get; set; }
    }
    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
