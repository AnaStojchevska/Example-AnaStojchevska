using Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TodoContext _context;
        public TransactionRepository(TodoContext context)
        {
            _context = context;
        }
        public async Task Add(Transaction t)
        {
            _context.Transaction.Add(t);
            await _context.SaveChangesAsync();
                }

        public async Task Delete(string id)
        {
            var itemToDelete = await _context.Transaction.FindAsync(id);
            if (itemToDelete == null)
                throw new NullReferenceException();
            _context.Transaction.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Transaction> Get(string id)
        {
            return await _context.Transaction.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _context.Transaction.ToListAsync();
        }
    }
}
