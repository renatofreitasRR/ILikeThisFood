using ILikeThisFood.Domain.Entities;
using ILikeThisFood.Domain.InputModels.Company;
using ILikeThisFood.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ILikeThisFood.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Company> companies = await _companyRepository.GetAllAsync();

            return Ok(companies);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            Company company = await _companyRepository.GetAsync(id);

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateCompanyInputModel companyInputModel)
        {
            var company = new Company(companyInputModel.Name, companyInputModel.RegistreNumber);

            await _companyRepository.CreateAsync(company);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateCompanyInputModel companyInputModel)
        {
            var company = new Company(companyInputModel.Id, companyInputModel.Name, companyInputModel.RegistreNumber);

            await _companyRepository.UpdateAsync(company);

            return Ok();
        }
    }
}
