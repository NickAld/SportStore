using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите имя получателя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите адрес")]
        public string Address { get; set; }
        [Required (ErrorMessage ="Укажите город")]
        public string City { get; set; }

        public bool GiftWrap { get; set; }
    }
}
