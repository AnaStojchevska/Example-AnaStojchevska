using Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TodoContext _context;
        public CategoryRepository(TodoContext context)
        {
            _context = context;
        }
        public async Task Add(Category c)
        {
            _context.Category.Add(c);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string Code)
        {
            var itemToDelete = await _context.Category.FindAsync(Code);
            _context.Category.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> Get(string Code)
        {
            return await _context.Category.FindAsync(Code);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Category.ToListAsync();
        }
    }
}
