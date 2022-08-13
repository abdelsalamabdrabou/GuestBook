using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(256)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(256)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
