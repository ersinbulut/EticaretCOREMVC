using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product GetById(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetListAll();
        }

        public List<Product> GetList(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByID(int id)
        {
            return _productDal.GetListAll(x => x.Id == id);
        }

        public List<Product> GetProductListWithCategory()
        {
            return _productDal.GetListWithCategory();
        }

		public void TAdd(Product t)
		{
            _productDal.Insert(t);
        }

		public void TDelete(Product t)
		{
            _productDal.Delete(t);
        }

		public void TUpdate(Product t)
		{
            _productDal.Update(t);
        }
	}
}
