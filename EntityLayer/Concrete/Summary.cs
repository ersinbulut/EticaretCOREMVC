using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Summary
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int musteriID { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }


        //public int CategoryId { get; set; }//bir ürünün bir kategorisi vardır bir kategorinin birden fazla ürünü olabilir.
        //public int ParentId { get; internal set; }
        //public virtual Category Category { get; set; }

        //public virtual List<ProductCategory> ProductCategories { get; set; }
    }
}
