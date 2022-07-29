using Example.Models;

namespace Example.Repositories
{
    public interface ITransactionRepository

    {
        Task<Transaction> Get(string id);
        Task<IEnumerable<Transaction>> GetAll();

        Task Add(Transaction t);
        Task Delete(string id);
    
    }
}
