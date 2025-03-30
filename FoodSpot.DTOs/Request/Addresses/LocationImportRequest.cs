using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.DTOs.Request.Addresses
{
    public class LocationImportRequest
    {
        public IFormFile FileData { get; set; }
    }
}
