using ILikeThisFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.Repositories
{
    public interface IFoodRepository
    {
        Task<Food> GetAsync(string id);
        Task<IEnumerable<Food>> GetAllAsync();
        Task CreateAsync(Food food);
        Task UpdateAsync(Food food);
        Task DeleteAsync(string id);
        Task PutPhoto(string id, string photoUrl);
    }
}
