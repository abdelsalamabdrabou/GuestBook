using GuestBook.DataAccess.Repository.IRepository;
using GuestBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GuestBook.Controllers
{
    public class MessageReplyController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly MessageVM messageVM;
        public MessageReplyController(IUnitOfWork unit)
        {
            var Init = new Init(unit);
            _unit = unit;
            messageVM = Init.InitMessageVM();
        }

        [HttpPost]
        [Route("/Messages/Index")]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MessageReply messageReply)
        {
            if (ModelState.IsValid)
            {
                messageReply.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _unit.MessageReply.Add(messageReply);
                return RedirectToAction(nameof(Index), "Messages");
            }

            return View("../Messages/Index", messageVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _unit.MessageReply.Delete(id);
            return RedirectToAction(nameof(Index), "Messages");
        }
    }
}
