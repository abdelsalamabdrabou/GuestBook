using Microsoft.AspNetCore.Mvc;

namespace GuestBook.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
