using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public string Topic { get; set; }
        public string Text { get; set; }

    }
}
