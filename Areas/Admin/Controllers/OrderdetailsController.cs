using Jewelly.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelly.Areas.Admin.Controllers
{
    public class OrderdetailsController : Controller
    {
        JwelleyEntities db = new JwelleyEntities();

        // GET: Admin/Orderdetails
        public ActionResult Orderdetails()
        {

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            List<ProdMst> prods = db.ProdMsts.ToList();
            //  var orderDetail = db.Orderdetails.Include(od => od.ItemMst).Include(od => od.ItemMst.ProdMst).ToList();
             List<Orderdetail> orderdetails = db.Orderdetails.ToList();

            return View(orderdetails);
        }
        public ActionResult Edit(int id)
        {
            var orderDetail = db.Orderdetails
                        .Include(od => od.ItemMst)
                        .Where(row => row.Orderdetails_ID == id)
                        .FirstOrDefault();

            if (orderDetail != null)
            {
                var products = db.ProdMsts.ToList();
                var Orderd = db.Orderdetails.ToList();

                var viewModel = new Orderdetailedit
                {
                    OrderDetail = orderDetail,
                    Products = new SelectList(products, "Prod_ID", "Prod_Type", orderDetail.ItemMst.ProdMst.Prod_ID),
                    Quantity = orderDetail.Quantity,
                    UnitPrice = orderDetail.UnitPrice,
                    ID = orderDetail.ID,
                };

                return View(viewModel);
            }
            else
            {
                TempData["error"] = "Error Edit!!";
                return View();
            }
        }
        //[HttpPost]
        //public ActionResult Edit(Orderdetail od)
        //{
        //    Orderdetail orderdetail1 = db.Orderdetails.Where(row => row.Orderdetails_ID == od.Orderdetails_ID).FirstOrDefault();
        //    if (orderdetail1 != null)
        //    {
        //        orderdetail1.Quantity = od.Quantity;
        //        orderdetail1.UnitPrice = od.UnitPrice;
        //        orderdetail1.ID = od.ID;
        //        orderdetail1.Style_Code = od.Style_Code;
        //        db.SaveChanges();
        //        TempData["result"] = "Edit Orderdetails successfully!";

        //        return RedirectToAction("Orderdetails", "Orderdetails");
        //    }
        //    else
        //    {
        //        TempData["error"] = "Error Edit!!";
        //        return View();
        //    }
        //}
        [HttpPost]
        public ActionResult Edit(Orderdetailedit viewModel)
        {
            var orderdetail1 = db.Orderdetails
                                .Include(od => od.ItemMst)
                                .Where(row => row.Orderdetails_ID == viewModel.OrderDetail.Orderdetails_ID)
                                .FirstOrDefault();

            if (orderdetail1 != null)
            {
                orderdetail1.Quantity = viewModel.OrderDetail.Quantity;
                orderdetail1.UnitPrice = viewModel.OrderDetail.UnitPrice;
                orderdetail1.ID = viewModel.OrderDetail.ID;
                orderdetail1.Style_Code = viewModel.OrderDetail.Style_Code;

                // Cập nhật giá trị khóa ngoại trong bảng ItemMst
                orderdetail1.ItemMst.ProdMst.Prod_ID = viewModel.OrderDetail.ItemMst.ProdMst.Prod_ID;

                db.SaveChanges();
                TempData["result"] = "Edit Orderdetails successfully!";
                return RedirectToAction("Orderdetails", "Orderdetails");
            }
            else
            {
                TempData["error"] = "Error Edit!!";
                return View();
            }
        }

        public ActionResult Delete(int ID)
        {
            var Orderdetails = db.Orderdetails.Where(x => x.Orderdetails_ID == ID).FirstOrDefault();
            if (Orderdetails != null)
            {
                db.Orderdetails.Remove(Orderdetails);
                db.SaveChanges();
                TempData["result"] = "Delete Orderdetails successfully!";
                return RedirectToAction("Orderdetails", "Orderdetails");
            }
            else
            {
                TempData["error"] = "Error Delete!!";
                return View();

            }

        }
    }
}