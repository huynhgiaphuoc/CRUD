using Jewelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelly.Areas.Admin.Controllers
{
    public class CollectionController : Controller
    {
        JwelleyEntities db = new JwelleyEntities();
        // GET: Admin/Collection
        public ActionResult Collection()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            List<Collection> collections = db.Collections.ToList();
            return View(collections);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Collection collection)
        {
            if (ModelState.IsValid)
            {
                db.Collections.Add(collection);
                db.SaveChanges();
                TempData["result"] = "Add Payment Successfully!";
                return RedirectToAction("collection", "collection");
            }
            else
            {
                TempData["error"] = "Error Add!!";
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Collection collection = db.Collections.Where(row => row.collection_ID == id).FirstOrDefault();
            return View(collection);
        }
        [HttpPost]
        public ActionResult Edit(Collection collection)
        {
            Collection collection1 = db.Collections.Where(row => row.collection_ID == collection.collection_ID).FirstOrDefault();
            if (collection1 != null)
            {
                collection1.CGmail = collection.CGmail;
                db.SaveChanges();
                TempData["result"] = "Edit Product successfully!";

                return RedirectToAction("Collection", "Collection");
            }
            else
            {
                TempData["error"] = "Error Edit!!";
                return View();
            }
        }

        public ActionResult Delete(int ID)
        {
            var collection = db.Collections.Where(x => x.collection_ID == ID).FirstOrDefault();
            if (collection != null)
            {
                db.Collections.Remove(collection);
                db.SaveChanges();
                TempData["result"] = "Delete Collection successfully!";
                return RedirectToAction("Collection", "Collection");
            }
            else
            {
                TempData["error"] = "Error Delete!!";
                return View();

            }


        }
    }
}