using System;
using System.Collections.Generic;
using System.Linq;
using TrabajoFinalApis.Entities;
using TrabajoFinalApis.Model.Dto.Category.Request;
using TrabajoFinalApis.Model.Dto.Category.Response;
using TrabajoFinalApis.Model.Dto.Category; // CategoryUpdateRequestDto
using TrabajoFinalApis.Repository.Interfaces;
using TrabajoFinalApis.Service.Interface;

namespace TrabajoFinalApis.Service.Implementation;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IRestaurantRepository _restaurantRepository;

    public CategoryService(ICategoryRepository categoryRepository,IRestaurantRepository restaurantRepository)
    {
        _categoryRepository = categoryRepository;
        _restaurantRepository = restaurantRepository;
    }

    public IEnumerable<CategoryResponseDto> GetByRestaurant(int restaurantId)
    {
        // Verificamos que el restaurante exista
        if (_restaurantRepository.Exists(restaurantId) == false)
        {
            throw new Exception("El restaurante no existe");
        }

        var categories = _categoryRepository.GetByRestaurantId(restaurantId);

        // Por las dudas filtramos solo activas, aunque el repo ya lo puede hacer
        var activeCategories = categories.Where(c => c.IsActive);

        return activeCategories
            .Select(MapToCategoryResponseDto)
            .ToList();
    }

    public CategoryResponseDto Create(int restaurantId, int UserId, CategoryCreateRequestDto dto)
    {
        // Validar que el restaurante existe y pertenece al usuario logueado
        if (!_restaurantRepository.BelongsToUser(restaurantId, UserId))
            throw new UnauthorizedAccessException(
                "No podés crear categorías para un restaurante que no es tuyo.");

        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description,
            IsActive = true,
            RestaurantId = restaurantId
        };

        _categoryRepository.Add(category);
        _categoryRepository.SaveChanges();

        return MapToCategoryResponseDto(category);
    }

  
    public CategoryResponseDto Update(
        int categoryId,
        int UserId,
        CategoryUpdateRequestDto dto)
    {
        var category = _categoryRepository.GetById(categoryId);

        if (category == null || !category.IsActive)
            throw new KeyNotFoundException("La categoría no existe o está desactivada.");

        // Verificamos que el restaurante dueño de esta categoría sea del usuario logueado
        if (!_restaurantRepository.BelongsToUser(category.RestaurantId, UserId))
            throw new UnauthorizedAccessException(
                "No podés modificar una categoría de un restaurante que no es tuyo.");

        category.Name = dto.Name;
        category.Description = dto.Description;

        _categoryRepository.Update(category);
        _categoryRepository.SaveChanges();

        return MapToCategoryResponseDto(category);
    }



    public void Remove(int categoryId, int UserId)
    {
        var category = _categoryRepository.GetById(categoryId);

        if (category == null || !category.IsActive)
            throw new KeyNotFoundException("La categoría no existe o ya está desactivada.");

        if (!_restaurantRepository.BelongsToUser(category.RestaurantId, UserId))
            throw new UnauthorizedAccessException(
                "No podés eliminar una categoría de un restaurante que no es tuyo.");

        category.IsActive = false;

        _categoryRepository.Update(category);
        _categoryRepository.SaveChanges();
    }

    private static CategoryResponseDto MapToCategoryResponseDto(Category category)
    {
        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}
