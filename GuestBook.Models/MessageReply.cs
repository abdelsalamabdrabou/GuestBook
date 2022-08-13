using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Models
{
    public class MessageReply
    {
        public int MessageReplyId { get; set; }
        public int MessageId { get; set; }
        [ForeignKey("MessageId")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public string Text { get; set; }
    }
}
