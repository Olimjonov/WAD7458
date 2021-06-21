using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WAD.WebApp._7458.DAL.DBO;

namespace WAD.WebApp._7458.DAL.Repository
{
    public class BikeRepository : BaseRepository, IRepository<Bike>
    {
        public BikeRepository(BikeDbContext context)
            : base(context)
        {
        }

        public async Task CreateAsync(Bike bike)
        {
            _dbContext.Add(bike);
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

        public async Task<List<Bike>> GetAllAsync()
        {
            return await _dbContext.Bike.ToListAsync();
        }

        public Task<Bike> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Bike steak)
        {
            throw new NotImplementedException();
        }
    }
}
