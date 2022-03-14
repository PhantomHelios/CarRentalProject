using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? Returndate { get; set; }
    }
}
