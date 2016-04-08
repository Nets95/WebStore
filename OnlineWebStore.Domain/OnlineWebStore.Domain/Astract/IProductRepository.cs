﻿using OnlineWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineWebStore.Domain.Astract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
