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
        public Task<List<Bike>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
