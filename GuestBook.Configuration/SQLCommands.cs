using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Configuration
{
    public static class SQLCommands
    {
        public const string Find = $"SELECT * FROM Messages WHERE MessageId = @messageId";
        public const string GetAll = $"SELECT * FROM Messages";
        public const string Add = $"INSERT INTO Messages(UserId, Topic, Text) VALUES(@userId, @topic, @text)";
        public const string Update = $"UPDATE Messages SET Topic = @topic, Text = @text WHERE MessageId = @messageId";
        public const string Delete = $"DELETE FROM Messages WHERE MessageId = @messageId";
    }
}
