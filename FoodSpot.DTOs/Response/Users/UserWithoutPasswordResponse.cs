using FoodSpot.Domain;
using FoodSpot.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.DTOs.Response.Users
{
    public class UserWithoutPasswordResponse : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
    }
}
