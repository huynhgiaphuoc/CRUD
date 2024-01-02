using Jewelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelly.Areas.Admin.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Admin/Payment
        JwelleyEntities db=  new JwelleyEntities();
        public ActionResult Payment(string search="")
        {
            List<Payment> payment = db.Payments.Where(x => x.type.Contains(search)).ToList();

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }


            return View(payment);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Payment payment) {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                TempData["result"] = "Add Payment Successfully!";
                return RedirectToAction("Payment","Payment");
            }
            else
            {
                TempData["error"] = "Error Add!!";
                return View();
            }

        }
        public ActionResult Edit(int id)
        {
            Payment payment = db.Payments.Where(row => row.ID == id).FirstOrDefault();
            return View(payment);
        }
        [HttpPost]
        public ActionResult Edit(Payment pay)
        {
            Payment payment = db.Payments.Where(row => row.ID == pay.ID).FirstOrDefault();
            if (payment != null)
            {
                payment.type = pay.type;
                payment.numbercard = pay.numbercard;
                payment.cgv= pay.cgv;
                payment.expiration_date= pay.expiration_date;
                db.SaveChanges();
                TempData["result"] = "Edit Product successfully!";

                return RedirectToAction("Payment", "Payment");
            }
            else
            {
                TempData["error"] = "Error Edit!!";
                return View();
            }
        }

        public ActionResult Delete(int ID)
        {
            var payment = db.Payments.Where(x => x.ID == ID).FirstOrDefault();
            if (payment != null)
            {
                db.Payments.Remove(payment);
                db.SaveChanges();
                TempData["result"] = "Delete Product successfully!";
                return RedirectToAction("Payment", "Payment");
            }
            else
            {
                TempData["error"] = "Error Delete!!";
                return View();

            }

        }

    }
}