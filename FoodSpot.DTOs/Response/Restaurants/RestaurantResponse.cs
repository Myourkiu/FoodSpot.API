using FoodSpot.Domain;
using FoodSpot.DTOs.Response.Addresses;
using FoodSpot.DTOs.Response.Users;
using FoodSpot.DTOs.Response.MenuItems;

namespace FoodSpot.DTOs.Response.Restaurants
{
    public class RestaurantResponse : EntityBase
    {
        public string Cnpj { get; set; }
        public AddressResponse Address { get; set; }
        public UserWithoutPasswordResponse User { get; set; }
        public ICollection<MenuItemResponse>? MenuItems { get; set; }
    }
}
