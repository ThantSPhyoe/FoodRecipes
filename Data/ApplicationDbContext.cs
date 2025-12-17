using FoodRecipe.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipe.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public DbSet<Steps> Steps { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<RecipeCategories> RecipeCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RecipeIngredients>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder.Entity<RecipeIngredients>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredients>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            modelBuilder.Entity<RecipeCategories>()
                .HasKey(rc => new { rc.RecipeId, rc.CategoryId });

            modelBuilder.Entity<RecipeCategories>()
                .HasOne(rc => rc.Recipe)
                .WithMany(r => r.RecipeCategories)
                .HasForeignKey(rc => rc.RecipeId);

            modelBuilder.Entity<RecipeCategories>()
                .HasOne(rc => rc.Category)
                .WithMany(c => c.RecipeCategories)
                .HasForeignKey(rc => rc.CategoryId);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.User)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Recipe>()
                .Property(r => r.Difficulty)
                .HasConversion<string>();
        }
    }
}

