using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands;

public class CreateCategoryCommand : IRequest<CreatedCategoryDto>
{
    public string Name { get; set; }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _businessRules;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules rules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _businessRules = rules;
        }

        public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);

            Category mappedCategory = _mapper.Map<Category>(request);
            Category createdCategory = await _categoryRepository.AddAsync(mappedCategory);
            CreatedCategoryDto createdCategoryDto = _mapper.Map<CreatedCategoryDto>(createdCategory);
            return createdCategoryDto;
        }
    }
}
