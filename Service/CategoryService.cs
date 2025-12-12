using FoodRecipe.Dtos;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Models;
using FoodRecipe.Repositories;

namespace FoodRecipe.Service
{
    public class CategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<Categories> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public Categories GetCategoryById(int Id)
        {
            try
            {
                Categories category = categoryRepository.FindCategoryById(Id);
                if (category == null) throw new InvalidOperationException($"Category not found. ID: {Id}");
                return category;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CategoryDto CreateCategory(CreateCategoryRequestDto dto)
        {
            try
            {
                Categories category = categoryRepository.CreateCategory(new Categories
                {
                     Name = dto.Name,
                     CreatedAt = DateTime.UtcNow,
                     UpdatedAt = DateTime.UtcNow
                });
                if( category == null) throw new InvalidOperationException("Failed to create category.");
                return new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public CategoryDto UpdateCategory(UpdateCategoryRequestDto dto)
        {
            try
            {
                Categories category = categoryRepository.FindCategoryById(dto.Id);
                if (category == null) throw new InvalidOperationException($"Category not found. ID: {dto.Id}");
                category.Name = dto.Name;
                category.UpdatedAt = DateTime.UtcNow;
                var updatedCategory = categoryRepository.UpdateCategory(category);
                return new CategoryDto
                {
                    Name = updatedCategory.Name
                };
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
