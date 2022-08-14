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
        private readonly MessageVM messageVM;
        public MessagesController(IUnitOfWork unit)
        {
            var Init = new Init(unit);
            _unit = unit;
            messageVM = Init.InitMessageVM();
        }
        public IActionResult Index(int id)
        {
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

            return View(messageVM);
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

            messageVM.Message = message;

            return View(nameof(Index), messageVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _unit.Message.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
