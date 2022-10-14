using Microsoft.AspNetCore.Mvc;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMaster.Web.Controllers
{
    [Route("[Controller]")]
    public class RetailerController : Controller
    {
        private readonly IRetailerService retailer;

        public RetailerController(IRetailerService retailer)
        {
            this.retailer = retailer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = retailer.GetRetailers();
            return View(list);
        }

        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {
            var dto = new RetailerVM();
            dto.ProductTypes = retailer.GetProductTypes();
            
            return View(dto);
        }

        [HttpPost]
        [Route("New")]
        public IActionResult New(RetailerVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                dto.ProductTypes = retailer.GetProductTypes();
                return View(dto);
            }

            retailer.AddRetailer(dto);

            return View("Index", retailer.GetRetailers());
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var dto = retailer.GetRetailer(id);
            dto.ProductTypes = retailer.GetProductTypes();
            return View(dto);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, RetailerVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                dto.ProductTypes = retailer.GetProductTypes();
                return View(dto);
            }

            retailer.UpdateRetailer(id, dto);

            return View("Index", retailer.GetRetailers());
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public JsonResult Delete(int id)
        {
            retailer.DeleteRetailer(id);
            return Json(new { success = true, message = "Delete success" });
        }
    }
}
