using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    /*
     * obtém todas as categorias do banco de dados por meio do repositório,
     * mapeia as entidades de categoria para DTOs de categoria usando o AutoMapper e
     * retorna a coleção resultante de DTOs de categoria. Este processo permite que os DTOs de
     * categoria sejam utilizados na camada de serviço e, eventualmente, transmitidos para a
     * camada de apresentação ou cliente da aplicação.
     */
    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoriesEntity = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDTO>(categoriesEntity);
    }

    /*
     * mapeia o DTO de categoria para a entidade de categoria usando o AutoMapper,
     * cria a entidade de categoria no banco de dados por meio do repositório e
     * atualiza o DTO de categoria com o identificador da categoria criada.
     */
    public async Task AddCategory(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Create(categoryEntity);
        categoryDto.CategoryId = categoryEntity.CategoryId;
    }

    public async Task UpdateCategory(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Update(categoryEntity);
    }

    public Task DeleteCategory(int id)
    {
        var categoryEntity = _categoryRepository.GetById(id).Result;
        return _categoryRepository.Delete(categoryEntity.CategoryId);
    }
}