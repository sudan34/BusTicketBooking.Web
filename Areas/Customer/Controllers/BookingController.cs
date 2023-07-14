using Microsoft.AspNetCore.Mvc;

namespace BusTicketBooking.Web.Areas.Customer.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
