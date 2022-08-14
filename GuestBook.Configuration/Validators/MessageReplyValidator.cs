using FluentValidation;
using GuestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Configuration.Validators
{
    public class MessageReplyValidator : AbstractValidator<MessageReply>
    {
        public MessageReplyValidator()
        {
            RuleFor(m => m.Text).NotEmpty().Length(1, 50);            
        }
    }
}
