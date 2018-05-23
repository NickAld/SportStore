﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    using SportsStore.Domain.Entities;
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}