using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILikeThisFood.Domain.Entities;
using ILikeThisFood.Domain.Repositories;
using ILikeThisFood.Infra.Data.Context;
using ILikeThisFood.Infra.Data.DTO;
using MongoDB.Driver;

namespace ILikeThisFood.Infra.Data.Repositories
{
    public class CompanyRepository : DataContext, ICompanyRepository
    {
        private readonly IMongoCollection<CompanyDTO> _companiesCollection;

        public CompanyRepository() : base("Companies")
        {
            _companiesCollection = this._mongoDatabase.GetCollection<CompanyDTO>(this._collectionName);
        }

        public async Task CreateAsync(Company company)
        {
            var companyDTO = new CompanyDTO(company.Id, company.Name, company.RegistreNumber);

            await _companiesCollection.InsertOneAsync(companyDTO);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companiesDTO = await _companiesCollection
                .Find(_ => true)
                .ToListAsync();

            var companies = companiesDTO.Select(x => new Company(x.Name, x.RegistreNumber));

            return companies;
        }
    }
}
