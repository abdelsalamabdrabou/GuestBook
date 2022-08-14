using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Models
{
    public class MessageVM
    {
        public Message Message { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public MessageReply MessageReply { get; set; }
        public IEnumerable<MessageReply> MessageReplies { get; set; }

    }
}
