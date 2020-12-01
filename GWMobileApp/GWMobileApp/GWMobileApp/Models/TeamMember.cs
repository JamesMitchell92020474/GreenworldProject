using System;
using System.Collections.Generic;
using System.Text;

namespace GWMobileApp.Models
{
    public class TeamMember
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string DeptRole { get; set; }
        public string Image { get; set; }
        public bool IsPublic { get; set; }
    }
}
