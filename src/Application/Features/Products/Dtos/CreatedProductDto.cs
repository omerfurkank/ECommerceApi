﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Dtos;

public class CreatedProductDto : Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
}