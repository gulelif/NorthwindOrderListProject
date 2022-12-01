using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using NorthwindOrderListProject.Models;
using NorthwindOrderListProject.Validators;
using System.Text.RegularExpressions;

namespace NorthwindOrderListProject.Controllers
{
    public class ShipperController : Controller
    {
        private readonly NorthwindContext _context;
        public ShipperController(NorthwindContext context)
        {
            _context= context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Shipper shipper)
        {
            ShipperValidator validator = new ShipperValidator();

            ValidationResult result = validator.Validate(shipper);

            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();

            }
            shipper.Phone = Regex.Replace(shipper.Phone, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
           
       
            _context.Shippers.Add(shipper);
            _context.SaveChanges();
            ViewBag.message = "Success!";

            return View();
           
        }
    }
}
