using GuestBook.DataAccess.Repository.IRepository;
using GuestBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GuestBook.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        /*
         * 
         * Fluent Validation
         * Reply Messages
         */
        private readonly IUnitOfWork _unit;
        public MessagesController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index(int id)
        {
            var messageVM = new MessageVM()
            {
                Message = new(),
                Messages = _unit.Message.GetAll(),
                MessageReply = new(),
                MessageReplies = _unit.MessageReply.GetAll()
            };

            if (id != 0)
                messageVM.Message = _unit.Message.Find(id);

            return View(messageVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Message message)
        {
            if (ModelState.IsValid)
            {
                message.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _unit.Message.Add(message);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                _unit.Message.Update(message);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _unit.Message.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
