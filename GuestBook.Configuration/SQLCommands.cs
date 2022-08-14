using GuestBook.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Configuration
{
    public static class SQLCommands
    {
        public static Message Message { get; } = new Message();
        public static MessageReply MessageReply { get; } = new MessageReply();
    }
}
