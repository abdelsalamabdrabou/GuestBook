using FluentValidation;
using GuestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Configuration.Validators
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.Topic).NotEmpty().Length(10, 50);
            RuleFor(m => m.Text).NotEmpty().Length(5, 1000);            
        }
    }
}
