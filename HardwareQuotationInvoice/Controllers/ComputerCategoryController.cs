using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessService;
using HardwareQuotationInvoice.Models;

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
            var modelView = new ComputerCatogryView { Name = "台式机", OrderPriorityId = 0 };
            _hardwareService.AddNewComputerType(Helper.AutoMapperHelper.MapTo<ComputerCategory>(modelView));
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
    }
}
