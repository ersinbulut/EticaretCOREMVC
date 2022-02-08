using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        //void ProductAdd(Product product);
        //void ProductDelete(Product product);
        //void ProductUpdate(Product product);
        
        //List<Product> GetList();
        //Product GetById(int id);

        List<Product> GetProductListWithCategory();
    }
}
