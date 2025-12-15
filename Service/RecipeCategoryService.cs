using FoodRecipe.Dtos;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Models;
using FoodRecipe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodRecipe.Service
{
    public class RecipeCategoryService
    {
        private readonly IRecipeCategoryRepository recipeCategoryRepository;

        public RecipeCategoryService(IRecipeCategoryRepository recipeCategoryRepository)
        {
            this.recipeCategoryRepository = recipeCategoryRepository;
        }

        public RecipeCategoryDto Create(CreateRecipeCategoryRequestDto dto)
        {
            var now = DateTime.UtcNow;

            var exists = recipeCategoryRepository.Find(dto.RecipeId, dto.CategoryId);
            if (exists != null) throw new InvalidOperationException("Recipe category already exists.");

            var entity = new RecipeCategories
            {
                RecipeId = dto.RecipeId,
                CategoryId = dto.CategoryId
            };

            var created = recipeCategoryRepository.Create(entity);
            return new RecipeCategoryDto { RecipeId = created.RecipeId, CategoryId = created.CategoryId };
        }

        public RecipeCategoryDto Update(UpdateRecipeCategoryRequestDto dto)
        {
            var existing = recipeCategoryRepository.Find(dto.RecipeId, dto.CategoryId);
            if (existing == null) throw new InvalidOperationException("Recipe category not found.");

            // change category id to new one
            existing.CategoryId = dto.NewCategoryId;
            var updated = recipeCategoryRepository.Update(existing);
            return new RecipeCategoryDto { RecipeId = updated.RecipeId, CategoryId = updated.CategoryId };
        }

        public string Delete(int recipeId, int categoryId)
        {
            var deleted = recipeCategoryRepository.Delete(recipeId, categoryId);
            if (!deleted) throw new InvalidOperationException("Recipe category not found.");
            return "Deleted successfully.";
        }

        public List<RecipeCategoryDto> SearchByRecipe(int recipeId)
        {
            var results = recipeCategoryRepository.SearchByRecipe(recipeId);
            return results.Select(rc => new RecipeCategoryDto { RecipeId = rc.RecipeId, CategoryId = rc.CategoryId }).ToList();
        }
    }
}