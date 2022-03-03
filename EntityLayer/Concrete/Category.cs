using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public Nullable<int> ParentCategoryID { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual Category ParentCategory { get; set; }

        public virtual List<ProductCategory> ProductCategories { get; set; }
    }


}

