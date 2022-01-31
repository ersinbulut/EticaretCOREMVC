using BusinessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //CategoryRepository categoryRepository = new CategoryRepository();
        GenericRepository<Category> repo = new GenericRepository<Category>();
        public void CategoryAdd(Category category)
        {
            //if (category.CategoryName!=""&& category.CategoryDescription!="" &&
            //    category.CategoryName.Length>=5 && category.CategoryStatus == true)
            //{
            //    categoryRepository.AddCategory(category);
            //}
            //else
            //{
            //    //Hata mesajı
            //}
            throw new NotImplementedException();
        }

        public void CategoryDelete(Category category)
        {
            if (category.Id != 0)
            {
                repo.Delete(category);
            }
        }

        public void CategoryUpdate(Category category)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
