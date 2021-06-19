using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WAD.WebApp._7458.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
    }
}
