using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodSpot.DTOs.Request.Addresses;
using FoodSpot.DTOs.Request.Users;

namespace FoodSpot.DTOs.Request.Customers
{
    public class CreateCustomerRequest
    {
        public string Cpf { get; set; }
        public CreateUserOnObjectRequest UserRequest { get; set; }
        public CreateAddressRequest AddressRequest { get; set; }
    }
}