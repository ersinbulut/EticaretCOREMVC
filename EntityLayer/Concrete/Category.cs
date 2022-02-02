using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        //Erişim Belirleyici Türü - Değişken Türü - İsim - {get set}

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public virtual List<Product> Products { get; set; }
        public int ParentId { get; set; }

        public virtual List<ProductCategory> ProductCategories { get; set; }
    }
}
