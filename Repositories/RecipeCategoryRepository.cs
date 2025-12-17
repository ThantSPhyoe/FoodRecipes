using FoodRecipe.Data;
using FoodRecipe.Models;


namespace FoodRecipe.Repositories
{
    public class RecipeCategoryRepository : IRecipeCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RecipeCategories Find(int recipeId, int categoryId)
        {
            return _context.RecipeCategories.FirstOrDefault(rc => rc.RecipeId == recipeId && rc.CategoryId == categoryId);
        }

        public RecipeCategories Create(RecipeCategories entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public RecipeCategories Update(RecipeCategories entity)
        {
            // For many-to-many simple join table, update might mean changing CategoryId
            _context.RecipeCategories.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int recipeId, int categoryId)
        {
            var existing = Find(recipeId, categoryId);
            if (existing == null) return false;
            _context.RecipeCategories.Remove(existing);
            _context.SaveChanges();
            return true;
        }

        public List<RecipeCategories> SearchByRecipe(int recipeId)
        {
            return _context.RecipeCategories.Where(rc => rc.RecipeId == recipeId).ToList();
        }

        public int CreateWithValidation(int recipeId, IEnumerable<int> categoryIds)
        {
            var distinctCategoryIds = categoryIds.Distinct().ToList();

            var existingCategoryIds = _context.Categories
                .Where(c => distinctCategoryIds.Contains(c.Id))
                .Select(c => c.Id)
                .ToList();

            var missingCategoryIds = distinctCategoryIds
                .Except(existingCategoryIds).ToList();

            if (missingCategoryIds.Any())
            {
                throw new InvalidOperationException(
                    $"Invalid CategoryId(s): {string.Join(", ", missingCategoryIds)}"
                );
            }

            var recipeCategories = distinctCategoryIds.Select(categoryId =>
            new RecipeCategories
            {
                RecipeId = recipeId,
                CategoryId = categoryId
            }).ToList();

            _context.RecipeCategories.AddRange(recipeCategories);
            var result = _context.SaveChanges();

            return result;

        }
    }
}