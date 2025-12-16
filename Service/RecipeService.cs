using FoodRecipe.Dtos;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Models;
using FoodRecipe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodRecipe.Service
{
    public class RecipeService
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly ICategoryRepository categoryRepository;

        public RecipeService(IRecipeRepository recipeRepository, ICategoryRepository categoryRepository)
        {
            this.recipeRepository = recipeRepository;
            this.categoryRepository = categoryRepository;
        }

        public RecipeDto CreateRecipe(CreateRecipeRequestDto dto)
        {
            try
            {
                var now = DateTime.UtcNow;
                var recipe = new Recipe
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Difficulty = dto.Difficulty,
                    ImageUrl = dto.ImageUrl,
                    UserId = dto.UserId,
                    CreatedAt = now,
                    UpdatedAt = now
                };

                var created = recipeRepository.Create(recipe);
                return MapToDto(created);
            }
            catch
            {
                throw;
            }
        }

        public RecipeDto UpdateRecipe(UpdateRecipeRequestDto dto)
        {
            try
            {
                var existing = recipeRepository.FindById(dto.Id);
                if (existing == null) throw new InvalidOperationException($"Recipe not found. ID: {dto.Id}");

                existing.Title = dto.Title;
                existing.Description = dto.Description;
                existing.Difficulty = dto.Difficulty;
                existing.ImageUrl = dto.ImageUrl;
                existing.UpdatedAt = DateTime.UtcNow;

                var updated = recipeRepository.Update(existing);
                return MapToDto(updated);
            }
            catch
            {
                throw;
            }
        }

        public string DeleteRecipe(int id)
        {
            try
            {
                var deleted = recipeRepository.Delete(id);
                if (!deleted) throw new InvalidOperationException("Recipe not found.");
                return "Deleted successfully.";
            }
            catch
            {
                throw;
            }
        }

        public List<RecipeDto> SearchRecipes(string query)
        {
            var results = recipeRepository.Search(query ?? string.Empty);
            return results.Select(MapToDto).ToList();
        }

        public RecipeDto GetRecipeById(int id)
        {
            var recipe = recipeRepository.FindById(id);
            if (recipe == null) throw new InvalidOperationException($"Recipe not found. ID: {id}");
            return MapToDto(recipe);
        }

        public HomePageDto GetAllDataForHomePage()
        {
            try
            {
                int Count = recipeRepository.GetTotalRecipesCount();

                List<Categories> Category = categoryRepository.GetAllCategories();
                List<Recipe> FirstThreeRecipe = recipeRepository.GetOnlyThreeRecipes();

                return new HomePageDto
                {
                    Count = Count,
                    Category = Category.Select(c => new CategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList(),
                    Recipes = FirstThreeRecipe.Select(r => new RecipeDto
                    {
                        Id = r.Id,
                        Title = r.Title,
                        Description = r.Description,
                        Difficulty = r.Difficulty,
                        ImageUrl = r.ImageUrl,
                        UserId = r.UserId,
                        UserName = r.User != null ? r.User.Username : string.Empty,
                        CreatedAt = r.CreatedAt,
                        UpdatedAt = r.UpdatedAt

                    }).ToList()
                };
            }catch
            {
                throw;
            }
        }

        public CategoryRecipeDto GetALLCategoryRecipe()
        {
            try
            {
               List<Categories> Category = categoryRepository.GetAllCategories();
               List<Recipe> Recipe = recipeRepository.GetAllRecipes();
                return new CategoryRecipeDto
                {
                     category = Category.Select(c => new CategoryDto
                     {
                          Id = c.Id,
                          Name = c.Name
                     }).ToList(),
                     recipe = Recipe.Select(r => new RecipeDto
                     {
                          Id = r.Id,
                          Title = r.Title,
                          Description = r.Description,
                          Difficulty = r.Difficulty,
                          ImageUrl = r.ImageUrl,
                          UserId = r.UserId,
                          UserName = r.User != null ? r.User.Username : string.Empty,
                          CreatedAt = r.CreatedAt,
                          UpdatedAt = r.UpdatedAt
    
                     }).ToList()
                };
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private RecipeDto MapToDto(Recipe r)
        {
            if (r == null) return null;
            return new RecipeDto
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                Difficulty = r.Difficulty,
                ImageUrl = r.ImageUrl,
                UserId = r.UserId,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            };
        }
    }
}