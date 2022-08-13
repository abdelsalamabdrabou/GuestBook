using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Configuration.Commands
{
    public class Message
    {
        public string Find { get; private set; }
        public string GetAll { get; private set; }
        public string Add { get; private set; }
        public string Update { get; private set; }
        public string Delete { get; private set; }
        public string Join { get; private set; }

        public Message()
        {
            Find = $"SELECT * FROM Messages WHERE MessageId = @messageId";
            GetAll = $"SELECT * FROM Messages";
            Add = $"INSERT INTO Messages(UserId, Topic, Text) VALUES(@userId, @topic, @text)";
            Update = $"UPDATE Messages SET UserId = @userId, Topic = @topic, Text = @text WHERE MessageId = @messageId";
            Delete = $"DELETE FROM Messages WHERE MessageId = @messageId";
        }
    }
}
