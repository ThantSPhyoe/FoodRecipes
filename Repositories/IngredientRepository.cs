using FoodRecipe.Data;
using FoodRecipe.Models;

namespace FoodRecipe.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {

        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Ingredients> GetAllIngredient()
        {
            return _context.Ingredients.ToList();
        }

        public Ingredients FindIngredientById(int Id)
        {
            Ingredients ingredient = _context.Ingredients.FirstOrDefault(c => c.Id == Id);
            return ingredient;
        }

        public Ingredients CreateIngredient(Ingredients ingredient)
        {
            _context.Add(ingredient);
            _context.SaveChanges();
            return ingredient;
        }

        public Ingredients UpdateIngredient(Ingredients ingredient)
        {
            _context.Ingredients.Update(ingredient);
            _context.SaveChanges();
            return ingredient;
        }

        public bool DeleteIngredientById(int Id)
        {
            Ingredients ingredient = _context.Ingredients.FirstOrDefault(c => c.Id == Id);
            if (ingredient == null) return false;
            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
            return true;
        }
    }
}
