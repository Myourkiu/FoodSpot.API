using FoodSpot.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.DTOs.Response.Users
{
    public class CreateUserResponse : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
