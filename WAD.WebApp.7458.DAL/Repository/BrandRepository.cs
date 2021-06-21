using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WAD.WebApp._7458.DAL.DBO;

namespace WAD.WebApp._7458.DAL.Repository
{
    public class BrandRepository : BaseRepository, IRepository<Brand>
    {
        public BrandRepository(BikeDbContext context)
            : base(context)
        {
        }

        public Task CreateAsync(Brand steak)
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

        public Task<List<Brand>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Brand> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Brand steak)
        {
            throw new NotImplementedException();
        }
    }
}
