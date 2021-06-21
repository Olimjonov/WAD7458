using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WAD.WebApp._7458.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T steak);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T steak);
        bool Exists(int id);
        Task DeleteAsync(int id);
    }
}
