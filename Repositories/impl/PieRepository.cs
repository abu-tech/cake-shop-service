
using System.Text.Json;
using CakeShop.Entites;
using CakeShopService.Entites;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Repositories.impl
{
    public class PieRepository : IPieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PieRepository> _logger;

        public PieRepository(ApplicationDbContext context, ILogger<PieRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Pie?> CreatePie(Pie pie)
        {
            var category = await _context.Categories.FindAsync(pie.CategoryId);

            if(category == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            if (category.Pies == null)
            {
                category.Pies = new List<int>();
            }

            await _context.Pies.AddAsync(pie); // Adds the new Pie to the context
            category.Pies.Add(pie.PieId); // Adds the Pie object to the Category's Pies collection
            await _context.SaveChangesAsync(); // Persists the changes in the database

            _logger.LogInformation("Creating pie with ID: {PieId}", pie.PieId);
            _logger.LogInformation("pie Object : {pie}", JsonSerializer.Serialize(pie));

            return pie; // Returns the created Pie object
        }

        public async Task<bool> DeletePie(int pieId)
        {
            var pie = await _context.Pies.FindAsync(pieId);
            if (pie == null)
            {
                return false;
            }

            _context.Pies.Remove(pie);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Pie>> GetAllpies()
        {
            return await _context.Pies.ToListAsync();
        }

        public async Task<Pie?> GetPieById(int pieId)
        {
            var pie = await _context.Pies.FindAsync(pieId);
            if(pie == null) 
            {
                return null;
            }
            return pie;
        }

        public async Task<IEnumerable<Pie>> PiesOfTheWeek()
        {
            return await _context.Pies.Where(p => p.IsPieOfTheWeek).ToListAsync();
        }

        public async Task<Pie?> UpdatePie(int pieId, Pie updatedPie)
        {
            var pie = await _context.Pies.FindAsync(pieId);
            if (pie == null)
            {
                return null;
            }

            pie.Name = updatedPie.Name;
            pie.ShortDescription = updatedPie.ShortDescription;
            pie.LongDescription = updatedPie.LongDescription;
            pie.AllergyInformation = updatedPie.AllergyInformation;
            pie.Price = updatedPie.Price;
            pie.ImageUrl = updatedPie.ImageUrl;
            pie.ImageThumbnailUrl = updatedPie.ImageThumbnailUrl;
            pie.IsPieOfTheWeek = updatedPie.IsPieOfTheWeek;
            pie.InStock = updatedPie.InStock;
            pie.CategoryId = updatedPie.CategoryId;

            await _context.SaveChangesAsync();

            return pie;
        }
    }
}
