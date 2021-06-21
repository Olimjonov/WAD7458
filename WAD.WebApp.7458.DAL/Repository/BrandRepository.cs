using Microsoft.EntityFrameworkCore;
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

        public async Task CreateAsync(Brand brand)
        {
            _dbContext.Add(brand);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _dbContext.Brand.ToListAsync();
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
