using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using blog_api_dotnet_core2.Interfaces;
using blog_api_dotnet_core2.Models;
using blog_api_dotnet_core2.Models.Context;

namespace blog_api_dotnet_core2.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly BlogDbContext _blogDbContext;

        public CategoryRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public IEnumerable<Category> FindAll()
        {
            return _blogDbContext.Categories.ToList();
        }

        public Category Find(Guid id)
        {
            return _blogDbContext.Categories.Find(id);
        }

        public Guid Add(Category category)
        {
            category.Id = Guid.NewGuid();
            
            category.CreatedAt = DateTime.Now;
            category.CreatedBy = "Roger Santana";

            _blogDbContext.Add(category);
            _blogDbContext.SaveChanges();

            return category.Id;
        }

        public Category Update(Category category)
        {
            var newCategory = _blogDbContext.Find<Category>(category.Id);

            newCategory.Name = category.Name;
            _blogDbContext.SaveChanges();
            
            return newCategory;
        }

        public void Delete(Guid id)
        {
            var category = _blogDbContext.Categories.Find(id);

            if (category != null)
            {
                category.IsDeleted = true;
                _blogDbContext.SaveChanges();
            }
        }
    }
}