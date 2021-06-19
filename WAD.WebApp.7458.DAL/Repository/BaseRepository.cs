using System;
using System.Collections.Generic;
using System.Text;

namespace WAD.WebApp._7458.DAL.DBO
{
    public class BaseRepository
    {
        protected readonly BikeDbContext _dbContext;

        protected BaseRepository(BikeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
