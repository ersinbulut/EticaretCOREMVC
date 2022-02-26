using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }

        public int BlogCategoryID { get; set; }
        public BlogCategory BlogCategory { get; set; }

        public int WriterID { get; set; }
        public Writer Writer { get; set; }

        public List<BlogComment> BlogComments { get; set; }
    }
}