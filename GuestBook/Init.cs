using GuestBook.DataAccess.Repository.IRepository;
using GuestBook.Models;

namespace GuestBook
{
    public class Init
    {
        private readonly IUnitOfWork _unit;
        public Init(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public MessageVM InitMessageVM()
        {
            var messageVM = new MessageVM()
            {
                Message = new(),
                Messages = _unit.Message.GetAll(),
                MessageReply = new(),
                MessageReplies = _unit.MessageReply.GetAll()
            };

            return messageVM;
        }
    }
}
