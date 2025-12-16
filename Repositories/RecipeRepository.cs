using FoodRecipe.Data;
using FoodRecipe.Models;
using FoodRecipe.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FoodRecipe.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Recipe> GetAllRecipe()
        {
            return _context.Recipes.ToList();
        }

        public Recipe FindById(int id)
        {
            return _context.Recipes
                .Include(r => r.RecipeIngredients)
                .Include(r => r.Steps)
                .Include(r => r.RecipeCategories)
                .FirstOrDefault(r => r.Id == id);
        }

        public List<Recipe> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return _context.Recipes
                    .Include(r => r.RecipeIngredients)
                    .Include(r => r.Steps)
                    .Include(r => r.RecipeCategories)
                    .ToList();
            }

            query = query.ToLower();
            return _context.Recipes
                .Include(r => r.RecipeIngredients)
                .Include(r => r.Steps)
                .Include(r => r.RecipeCategories)
                .Where(r => r.Title.ToLower().Contains(query) || r.Description.ToLower().Contains(query) || r.Difficulty.ToLower().Contains(query))
                .ToList();
        }

        public Recipe Create(Recipe recipe)
        {
            _context.Add(recipe);
            _context.SaveChanges();
            return recipe;
        }

        public Recipe Update(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
            return recipe;
        }

        public bool Delete(int id)
        {
            var existing = _context.Recipes.FirstOrDefault(r => r.Id == id);
            if (existing == null) return false;
            _context.Recipes.Remove(existing);
            _context.SaveChanges();
            return true;
        }

        public int GetTotalRecipesCount()
        {
            return _context.Recipes.Count();
        }

        public List<Recipe> GetOnlyThreeRecipes()
        {
            return _context.Recipes
                .Include(u => u.User)
                .Take(3)
                .ToList();
        }
    }
}