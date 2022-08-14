using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Configuration.Commands
{
    public class MessageReply
    {
        public string GetAll { get; private set; }
        public string GetAllById { get; private set; }
        public string Add { get; private set; }
        public string Delete { get; set; }

        public MessageReply()
        {
            GetAll = $"SELECT * FROM MessageReplies";
            GetAllById = $"SELECT * FROM MessageReplies WHERE MessageId = @messageId";
            Add = $"INSERT INTO MessageReplies(MessageId ,UserId, Text) VALUES(@messageId, @userId, @text)";
            Delete = $"DELETE FROM MessageReplies WHERE MessageReplyId = @messageReplyId";
        }
    }
}
