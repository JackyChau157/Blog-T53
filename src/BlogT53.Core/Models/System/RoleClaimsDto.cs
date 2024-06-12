using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogT53.Core.Models.System
{
    public class RoleClaimsDto
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string? DisplaName { get; set; }
        public bool Selected { get; set; }
    }
}