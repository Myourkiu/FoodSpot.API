using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Domain.Models.Users
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
