using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IProductDal
    {
        public void AddProduct(Product product)
        {
            using var c = new Context();
            c.Add(product);
            c.SaveChanges();
        }

        public void Delete(Product t)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            using var c = new Context();
            c.Remove(product);
            c.SaveChanges();
        }

        public Product GetById(int id)
        {
            using var c = new Context();
            return c.Products.Find(id);
        }

        public Product GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Product t)
        {
            throw new NotImplementedException();
        }

        public List<Product> ListAllProduct()
        {
            using var c = new Context();
            return c.Products.ToList();
        }

        public void Update(Product t)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            using var c = new Context();
            c.Update(product);
            c.SaveChanges();
        }
    }
}
