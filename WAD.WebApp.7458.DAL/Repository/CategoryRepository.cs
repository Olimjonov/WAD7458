using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WAD.WebApp._7458.DAL.DBO;

namespace WAD.WebApp._7458.DAL.Repository
{
    public class CategoryRepository : BaseRepository, IRepository<CategoryRepository>
    {
        public CategoryRepository(BikeDbContext context)
            : base(context)
        {
        }

        public Task CreateAsync(CategoryRepository steak)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryRepository>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryRepository> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CategoryRepository steak)
        {
            throw new NotImplementedException();
        }
    }
}
