using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Dtos;

public class CreatedCategoryDto : Dto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
