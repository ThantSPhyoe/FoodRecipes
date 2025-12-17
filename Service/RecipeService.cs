using Bedrock.Shared.Configuration;
using FoodRecipe.Data;
using FoodRecipe.Dtos;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Models;
using FoodRecipe.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipe.Service
{
    public class RecipeService
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IRecipeCategoryRepository recipeCategoryRepository;
        private readonly IUserRepository userRepository;

        public RecipeService(IRecipeRepository recipeRepository, ICategoryRepository categoryRepository, IRecipeCategoryRepository recipeCategoryRepository, IUserRepository userRepository)
        {
            this.recipeRepository = recipeRepository;
            this.categoryRepository = categoryRepository;
            this.recipeCategoryRepository = recipeCategoryRepository;
            this.userRepository = userRepository;
        }

        public RecipeDto CreateRecipe(CreateRecipeRequestDto dto)
        {
            try
            {
                var now = DateTime.UtcNow;
                var existingUser = userRepository.FindUserById(dto.UserId);
                if (existingUser == null) throw new InvalidOperationException($"User not found. ID: {dto.UserId}");

                var recipe = new Recipe
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Difficulty = dto.Difficulty,
                    ImageUrl = dto.ImageUrl,
                    ServeSize = dto.ServeSize,
                    VideoUrl = dto.VideoUrl,
                    TimeRequired = dto.TimeRequired,
                    UserId = dto.UserId,
                    CreatedAt = now,
                    UpdatedAt = now
                };

                var created = recipeRepository.Create(recipe);
                if (created == null) throw new InvalidOperationException("Failed to create recipe.");

                var result = recipeCategoryRepository.CreateWithValidation(created.Id, dto.CategoryId);
                if (result <= 0) throw new InvalidOperationException("Failed to associate categories");
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

                var existingUser = userRepository.FindUserById(dto.UserId);
                if (existingUser == null) throw new InvalidOperationException($"User not found. ID: {dto.UserId}");

                existing.Title = dto.Title;
                existing.Description = dto.Description;
                existing.Difficulty = dto.Difficulty;
                existing.ImageUrl = dto.ImageUrl;
                existing.ServeSize = dto.ServeSize;
                existing.VideoUrl = dto.VideoUrl;
                existing.TimeRequired = dto.TimeRequired;
                existing.UserId = dto.UserId;
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
                        Difficulty = r.Difficulty.ToString(),
                        ImageUrl = r.ImageUrl,
                        ServeSize = r.ServeSize,
                        VideoUrl = r.VideoUrl,
                        TimeRequired = r.TimeRequired,
                        CategoryName =  r.RecipeCategories.Select( rc => rc.Category.Name).FirstOrDefault() ?? string.Empty,
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
                          Difficulty = r.Difficulty.ToString(),
                          ImageUrl = r.ImageUrl,
                          ServeSize = r.ServeSize,
                          TimeRequired = r.TimeRequired,
                          VideoUrl = r.VideoUrl,
                         CategoryName = r.RecipeCategories != null && r.RecipeCategories.Any()
                    ? string.Join(", ", r.RecipeCategories.Select(rc => rc.Category.Name))
                    : string.Empty,
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
                Difficulty = r.Difficulty.ToString(),
                ImageUrl = r.ImageUrl,
                ServeSize = r.ServeSize,
                VideoUrl = r.VideoUrl,
                CategoryName  = r.RecipeCategories != null && r.RecipeCategories.Any()
                    ? string.Join(", ", r.RecipeCategories.Select(rc => rc.Category.Name))
                    : string.Empty,
                TimeRequired = r.TimeRequired,
                UserName = r.User != null ? r.User.Username : string.Empty,
                UserId = r.UserId,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            };
        }
    }
}