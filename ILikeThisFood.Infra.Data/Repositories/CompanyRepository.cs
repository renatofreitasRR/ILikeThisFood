using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILikeThisFood.Domain.Entities;
using ILikeThisFood.Domain.Repositories;
using ILikeThisFood.Infra.Data.Context;
using ILikeThisFood.Infra.Data.DTO;
using MongoDB.Bson;
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
            var companyDTO = new CompanyDTO(company.Name, company.RegistreNumber, company.FileUrl);

            await _companiesCollection.InsertOneAsync(companyDTO);
        }

        public async Task DeleteAsync(string id)
        {
            await _companiesCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companiesDTO = await _companiesCollection
                .Find(_ => true)
                .ToListAsync();

            var companies = companiesDTO.Select(x => new Company(x.Id, x.Name, x.RegistreNumber, x.FileUrl));

            return companies;
        }

        public async Task<Company> GetAsync(string id)
        {
            var companyDTO = await _companiesCollection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (companyDTO is null)
                throw new Exception();

            var company = new Company(companyDTO.Id, companyDTO.Name, companyDTO.RegistreNumber, companyDTO.FileUrl);

            return company;
        }

        public async Task PutFile(string id, string fileUrl)
        {
            var company = await this.GetAsync(id);
            company.SetFileUrl(fileUrl);

            await this.UpdateAsync(company);
        }

        public async Task UpdateAsync(Company company)
        {
            var companyDTO = new CompanyDTO(company.Id, company.Name, company.RegistreNumber, company.FileUrl);

            await _companiesCollection.ReplaceOneAsync(x => x.Id == company.Id.ToString(), companyDTO);
        }
    }
}
