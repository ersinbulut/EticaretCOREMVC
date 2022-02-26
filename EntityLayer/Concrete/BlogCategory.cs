using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class BlogCategory
    {
        [Key]
        public int BlogCategoryID { get; set; }
        public string BlogCategoryName { get; set; }
        public string BlogCategoryDescription { get; set; }
        public bool BlogCategoryStatus { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}