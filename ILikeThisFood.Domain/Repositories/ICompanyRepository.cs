using ILikeThisFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> GetAsync(string id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task CreateAsync(Company company);
        Task UpdateAsync(Company company);
    }
}
