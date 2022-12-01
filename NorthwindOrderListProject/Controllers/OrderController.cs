using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthwindOrderListProject.Models;

namespace NorthwindOrderListProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly NorthwindContext _context;
        public OrderController(NorthwindContext context)
        {
            this._context= context;

        }
        [HttpGet]
        public IActionResult Index()
        {      

                List<Order> orderList = new List<Order>();
            orderList = _context.Orders.Include(a => a.Employee).Include(b=>b.Customer).ToList();          
            return View(orderList);
        }

        [HttpGet]
        public IActionResult OrderDetails(int id)
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            orderDetailList = _context.OrderDetails.Include(a => a.Product).Where(a=>a.OrderId==id ).ToList();          
            return View(orderDetailList);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Order p)
        {
            return View();
        }
    }
}
