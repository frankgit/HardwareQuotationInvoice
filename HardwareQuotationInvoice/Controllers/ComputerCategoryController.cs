using HardwareQuotationInvoice.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardwareQuotationInvoice.Controllers
{
    public class ComputerCategoryController : Controller
    {
        // GET: ComputerCategory
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComputerCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComputerCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComputerCategory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ComputerCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComputerCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ComputerCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComputerCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ContentResult GetJsonData()
        {
            string filepath = Server.MapPath("~/App_Data/ComCategory.json");
            string json = CommonFunctionHelper.GetFileJson(filepath);
            return Content(json);
        }
    }
}
