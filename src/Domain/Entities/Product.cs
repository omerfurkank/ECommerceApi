﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }

    public Product()
    {
        
    }

    public Product(int id,string name, int stock, int price)
    {
        Id = id;
        Name = name;
        Stock = stock;
        Price = price;
    }
}
