using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodSpot.Domain.Models.Restaurants;

namespace FoodSpot.Infrastructure.Repositories.Interfaces.MenuItems
{
    public interface IMenuItemRepository
    {
        Task<MenuItem> Create(MenuItem menuItem);
    }
}
