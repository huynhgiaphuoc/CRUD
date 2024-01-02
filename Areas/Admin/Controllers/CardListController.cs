using Jewelly.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Jewelly.Areas.Admin.Controllers
{
    public class CardListController : Controller
    {
        JwelleyEntities db = new JwelleyEntities();
        public ActionResult CartList(string search="")
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            List<CartList> cartLists = db.CartLists.Where(x=>x.Product_Name.Contains(search)).ToList();
           return View(cartLists);     
        }
        public ActionResult Edit(int id)
        {
            CartList cartmst = db.CartLists.Where(row => row.ID== id).FirstOrDefault();
            return View(cartmst);
        }
        [HttpPost]
        public ActionResult Edit(CartList ct)
        {
            CartList cart = db.CartLists.Where(row => row.ID == ct.ID).FirstOrDefault();
            if (cart != null)
            {

                cart.Product_Name = ct.Product_Name;
                cart.MRP = ct.MRP;
                cart.Email_ID = ct.Email_ID;
                cart.OrderCode = ct.OrderCode;
                cart.OrderDate = ct.OrderDate;
                cart.ShipAddress = ct.ShipAddress;
                cart.ShipName = ct.ShipName;
                cart.ShipCity = ct.ShipCity;
                cart.ShipCode = ct.ShipCode;
                cart.ShipCountry = ct.ShipCountry;
           
                
                db.SaveChanges();
                return RedirectToAction("CartList", "CardList");
            }
            else
            {
                return View("EditProduct");
            }
        }
        public ActionResult Delete(int ID)
        {
            var cart = db.CartLists.Where(x=>x.ID== ID).FirstOrDefault();
           if(cart != null)
            {
                db.CartLists.Remove(cart);
                db.SaveChanges();
                TempData["result"] = "Delete Product successfully!";
                return RedirectToAction("CartList", "CardList");
            }
            else
            {
                return Json(new { success = false, message = "Không tìm thấy sản phẩm để xóa!" });
             
            }
            
        }
    }
}