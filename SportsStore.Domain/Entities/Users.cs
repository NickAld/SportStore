using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportsStore.Domain.Entities
{
    public class Users
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }

        [Required, MinLength(length:5), MaxLength(length:20)]
        public string UserName { get; set; }
        [Required, MinLength(length: 6), MaxLength(length: 20)]
        public string UserPassword { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int Accsess { get; set; }
    }
}