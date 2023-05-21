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

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateCompanyInputModel companyInputModel)
        {
            var company = new Company(companyInputModel.Name, companyInputModel.RegistreNumber);

            await _companyRepository.CreateAsync(company);

            return Ok();
        }
    }
}
