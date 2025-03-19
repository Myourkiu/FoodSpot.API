using FoodSpot.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.DTOs.Response.Users
{
    public class UserLoginResponse : User
    {
        public string Token { get; set; }
    }
}
