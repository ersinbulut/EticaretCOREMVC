using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }//sipariş durumu

        public string UserName { get; set; }

        //public string AdresBasligi { get; set; }
        //public string Adres { get; set; }
        //public string Il { get; set; }
        //public string Ilce { get; set; }
        //public string Mahalle { get; set; }
        //public string PostaKodu { get; set; }
        //*//*/

        public string CartNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string CartHasName { get; set; }
        public int ExpYear { get; set; }
        public int ExpMonth { get; set; }

        public bool Status { get; set; }
        //*//*/
        public virtual List<OrderLine> OrderLines { get; set; }

        //public string UserID { get; set; }
        //public Users User { get; set; }
        public int UserAddressID { get; set; }
        [ForeignKey("UserAddressID")]
        public virtual Addres Addres { get; set; }

        public int PayID { get; set; }
        [ForeignKey("PayID")]
        public virtual Pay Pay { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}

