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
        private readonly IRepository<Message> _repo;
        public MessagesController(IRepository<Message> repo)
        {
            _repo = repo;
        }
        public IActionResult Index(int id)
        {
            var messageVM = new MessageVM()
            {
                Message = new(),
                Messages = _repo.GetAll()
            };

            if (id != 0)
                messageVM.Message = _repo.Find(id);

            return View(messageVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Message message)
        {
            if (ModelState.IsValid)
            {
                message.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _repo.Add(message);
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
                _repo.Update(message);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
