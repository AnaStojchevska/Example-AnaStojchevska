using Example.Models;

namespace Example.Repositories
{
    public interface ICategoryRepository

    {
        Task<Category> Get(string id);
        Task<IEnumerable<Category>> GetAll();

        Task Add(Category c);
        Task Delete(string id);

    }
}
