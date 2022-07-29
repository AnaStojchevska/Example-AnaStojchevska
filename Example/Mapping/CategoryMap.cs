using CsvHelper.Configuration;
using Example.Models;
namespace Example.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Map(m => m.Code).Index(0);
            Map(m => m.Name).Name("name");
            Map(m => m.ParentCode).Name("parent-code");
           
        }
    }
}
