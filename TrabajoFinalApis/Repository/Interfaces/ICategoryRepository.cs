namespace TrabajoFinalApis.Repository.Interfaces;
using TrabajoFinalApis.Entities;

    public interface ICategoryRepository
    {
        void Create(Category newCategory);
        void Delete(int userId, int idCategory);
        void Update(Category UpdateCategory);
        IEnumerable<Category> GetAllCategories(int userId);
        Category? GetOneByUser(int userId, int categoryId);        
    }

