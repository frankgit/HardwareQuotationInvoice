using BusinessService;
using HardwareQuotationInvoice.Helper;
using HardwareQuotationInvoice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardwareQuotationInvoice.Controllers
{
    public class ComputerCategoryController : Controller
    {
        private IHardwareQuotaService _hardwareService;

        public ComputerCategoryController(IHardwareQuotaService hardwareService)
        {
            _hardwareService = hardwareService;
        }
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

        
        [HttpPost]
        public ActionResult Update(FormCollection collection)
        {
            try
            {
                var name = collection["name"];
                var priority = collection["priority"];
                var modelView = new ComputerCatogryView { Name = name, OrderPriorityId = int.Parse(priority) };
                _hardwareService.AddNewComputerType(Helper.AutoMapperHelper.MapTo<ComputerCategory>(modelView));


                return Content("ok");
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
