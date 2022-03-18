using CoreEticaret.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreEticaret.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart

        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(int Id)//karta ekle
        {
            //ürünü veri tabanına kaydet
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            Summary sum = new Summary();
            sum.ProductId = product.Id;
            sum.Name = product.Name;
            sum.Price = product.Price;
            sum.Stock = product.Stock;
            sum.musteriID = product.Stock;
        

            if (product != null)//eğer ürün veri tabanında var ise
            {
                db.Summaries.Add(sum);
                db.SaveChanges();
            }
            return RedirectToAction("ShopCart", "Product");
        }
        public ActionResult RemoveFromCart(int Id)//karttan sil
        {
            //ürünü veri tabanından sil
            var summary = db.Summaries.FirstOrDefault(i => i.Id == Id);
            if (summary != null)//eğer ürün veri tabanında var ise
            {
                db.Summaries.Remove(summary);
                db.SaveChanges();
            }
            return RedirectToAction("ShopCart", "Product");
        }

        public PartialViewResult Summary()
        {
            return PartialView();
        }
        /**/

        public ActionResult AddressList()
        {
            var addres = db.Addresses.Where(u => u.UserName == User.Identity.Name).ToList();
            return View(addres);
        }
        public ActionResult CreateUserAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserAddress(Address entity)
        {
            entity.UserName = User.Identity.Name;

            db.Addresses.Add(entity);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }

        public ActionResult DeleteUserAddress(int id)
        {
            Address addres = db.Addresses.Find(id);
            db.Addresses.Remove(addres);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }

        /**/
        public ActionResult PayList(int id)
        {
            Pay pay = new Pay();
            TempData["Adressid"] = id;
            pay.AddressID = id;
            db.Pays.Add(pay);
            //var pays = db.Pays.Where(u => u.AddressID == pay.AddressID).ToList();
            return View(db.Pays.Where(u => u.AddressID == pay.AddressID).ToList());
        }
        public ActionResult CreateUserPay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserPay(Pay entity, int id)
        {
            if (ModelState.IsValid)
            {
                entity.UserName = User.Identity.Name;
                entity.AddressID = id;
                db.Pays.Add(entity);
                db.SaveChanges();
                return RedirectToAction("PayList/" + entity.AddressID);
            }
            else
            {
                return View(entity);
            }

        }

        public ActionResult DeleteUserPay(int id)
        {
            Pay pay = db.Pays.Find(id);
            db.Pays.Remove(pay);
            db.SaveChanges();
            return RedirectToAction("PayList/" + pay.AddressID);
        }

        //public ActionResult CreateOrder()
        //{
        //    return View(new Addres());
        //}
        public ActionResult CreateOrder(List<Address> entity, List<Pay> entity1, int id, int payid)
        {
            //sepetteki ürün ile sipariş oluşturma..
            //var cart = GetCart();
            //if (/*cart.Cartlines.Count == 0*/)
            //{
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır..");
            //}
            if (ModelState.IsValid)//sepette ürün var ise
            {
                //SaveOrder(cart, entity, entity1, id, payid);
                //veri tabanına kaydet
                //cart.Clear();
                // return View("Complated");

                return RedirectToAction("Complated");
            }
            else
            {
                return View(entity1);
            }
        }
        private void SaveOrder(Cart cart, List<Address> entity, List<Pay> entity1, int id, int payid)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();//a harfi ile başlayan 4 haneli bir sipariş numarası 
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Bekleniyor;
            order.UserName = User.Identity.Name;
            order.UserAddressID = id;
            order.PayID = payid;

            order.OrderLines = new List<OrderLine>();
            foreach (var pr in cart.Cartlines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;
                orderline.Stock = pr.Product.Stock - orderline.Quantity;//
                order.OrderLines.Add(orderline);
            }

            db.Orders.Add(order);
            db.SaveChanges();
        }

        /**/
        //public ActionResult Checkout()
        //{
        //    return View(new ShippingDetails());
        //}

        //[HttpPost]
        //public ActionResult Checkout(ShippingDetails entity)
        //{
        //    var cart = GetCart();
        //    if (cart.Cartlines.Count == 0)
        //    {
        //        ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır..");
        //    }
        //    if (ModelState.IsValid)//sepette ürün var ise
        //    {
        //        SaveOrder(cart, entity);
        //        //veri tabanına kaydet
        //        cart.Clear();
        //        //return View("Complated");

        //        return RedirectToAction("Complated");
        //    }
        //    else
        //    {
        //        return View(entity);
        //    }

        //}

        //private void SaveOrder(Cart cart, ShippingDetails entity)
        //{
        //    var order = new Order();
        //    order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();//a harfi ile başlayan 4 haneli bir sipariş numarası 
        //    order.Total = cart.Total();
        //    order.OrderDate = DateTime.Now;
        //    order.OrderState = EnumOrderState.Bekleniyor;
        //    order.UserName = User.Identity.Name;
        //    order.AdresBasligi = entity.AdresBasligi;
        //    order.Adres = entity.Adres;
        //    order.Il = entity.Il;
        //    order.Ilce = entity.Ilce;
        //    order.Mahalle = entity.Mahalle;
        //    order.PostaKodu = entity.PostaKodu;
        //    /*kart bilgileri*/
        //    order.CartNumber = entity.CartNumber;
        //    order.SecurityNumber = entity.SecurityNumber;
        //    order.CartHasName = entity.CartHasName;
        //    order.ExpYear = entity.ExpYear;
        //    order.ExpMonth = entity.ExpMonth;
        //    /**/
        //    order.OrderLines = new List<OrderLine>();
        //    foreach (var pr in cart.Cartlines)
        //    {
        //        var orderline = new OrderLine();
        //        orderline.Quantity = pr.Quantity;
        //        orderline.Price = pr.Quantity * pr.Product.Price;
        //        orderline.ProductId = pr.Product.Id;
        //        orderline.Stock = pr.Product.Stock - orderline.Quantity;//
        //        order.OrderLines.Add(orderline);
        //    }

        //    db.Orders.Add(order);
        //    db.SaveChanges();
        //}

        public ActionResult Complated()
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.UserName == username).Select(i => new UserOrderModel
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total
            }).OrderByDescending(i => i.OrderDate).ToList();//azalan olarak sıraladık yani en son verilen sipariş en başa gelir.
            return View(orders);
            //orders tablosundaki bilgileri userOrderModel tablosunun içerisine paketledik
        }
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AdresBasligi = i.Addres.AdresBasligi,
                Adres = i.Addres.Adres,
                Il = i.Addres.Il,
                Ilce = i.Addres.Ilce,
                Mahalle = i.Addres.Mahalle,
                PostaKodu = i.Addres.PostaKodu,
                UserAddressID = i.UserAddressID,
                /*kart bilgileri*/
                CartNumber = i.Pay.CartNumber,
                SecurityNumber = i.Pay.SecurityNumber,
                CartHasName = i.Pay.CartHasName,
                ExpYear = i.Pay.ExpYear,
                ExpMonth = i.Pay.ExpMonth,
                /**/
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    Image = x.Product.Image,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList()
            }).FirstOrDefault();
            return View(entity);
        }
    }
}
