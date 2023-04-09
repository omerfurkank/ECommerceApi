using Application.Features.Categories.Dtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Queries;

public class GetByIdCategoryQuery : IRequest<GetCategoryDto>
{
    public int Id { get; set; }
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.Id);
            GetCategoryDto mappedCategoryDto = _mapper.Map<GetCategoryDto>(category);
            return mappedCategoryDto;
        }
    }
}
