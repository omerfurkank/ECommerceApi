using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands;

public class DeleteCategoryCommand : IRequest<DeletedCategoryDto>
{
    public int Id { get; set; }
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _businessRules;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules rules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _businessRules = rules;
        }

        public async Task<DeletedCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category mappedCategory = _mapper.Map<Category>(request);
            Category deletedCategory = await _categoryRepository.DeleteAsync(mappedCategory);
            DeletedCategoryDto deletedCategoryDto = _mapper.Map<DeletedCategoryDto>(deletedCategory);
            return deletedCategoryDto;
        }
    }
}