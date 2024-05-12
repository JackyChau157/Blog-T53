using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogT53.Core.Domain.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
        public string DisplayName { get; set; }
    }
}