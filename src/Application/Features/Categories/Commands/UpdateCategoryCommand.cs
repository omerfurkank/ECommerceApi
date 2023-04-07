using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands;

public class UpdateCategoryCommand : IRequest<UpdatedCategoryDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _businessRules;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules rules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _businessRules = rules;
        }

        public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category mappedCategory = _mapper.Map<Category>(request);
            Category updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory);
            UpdatedCategoryDto updatedCategoryDto = _mapper.Map<UpdatedCategoryDto>(updatedCategory);
            return updatedCategoryDto;
        }
    }
}