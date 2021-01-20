using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class AppUser : IdentityUser
    {

        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public ICollection<Hero> UserHeros { get; set; }

    }
}
