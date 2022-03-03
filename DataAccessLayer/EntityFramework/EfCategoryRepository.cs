using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        public List<Category> GetListAllParentCategory()
        {
            using (var c = new Context())
            {
                return c.Categories.ToList();
            }
        }

        public List<Category> GetListAllSubCategory(int? parentId = null)
        {
            using (var c = new Context())
            {
                return c.Categories.Where(x => x.ParentCategoryID.Equals(parentId)).Select(item => new Category
                {
                    Name = item.Name,
                    Id = item.Id,

                    Categories = GetListAllSubCategory(item.Id)
                }).ToList();
            }
        }
    }
}
