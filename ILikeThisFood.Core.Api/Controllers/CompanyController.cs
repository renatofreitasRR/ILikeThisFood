using Amazon.Runtime;
using ILikeThisFood.Domain.Entities;
using ILikeThisFood.Domain.InputModels.Company;
using ILikeThisFood.Domain.Repositories;
using ILikeThisFood.Services.Storage.Contracts;
using ILikeThisFood.Services.Storage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ILikeThisFood.Core.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;

        public CompanyController(
            ICompanyRepository companyRepository,
            IStorageService storageService,
            IConfiguration configuration)
        {
            _companyRepository = companyRepository;
            _storageService = storageService;
            _configuration = configuration;
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
            var company = new Company(companyInputModel.Name, companyInputModel.RegistreNumber, null);

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

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _companyRepository.DeleteAsync(id);

            return Ok();
        }

        [HttpPost("{id:length(24)}")]

        public async Task<IActionResult> UploadFile(string id, IFormFile file)
        {
            // Process file
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var fileExt = Path.GetExtension(file.FileName);
            var docName = $"{Guid.NewGuid()}{fileExt}";

            // call server
            var s3Obj = new S3Object()
            {
                BucketName = "ilikethisfoods3",
                InputStream = memoryStream,
                Name = docName
            };

            var cred = new AwsCredentials()
            {
                AccessKey = _configuration["AwsConfiguration:AWSAccessKey"],
                SecretKey = _configuration["AwsConfiguration:AWSSecretKey"]
            };

            var result = await _storageService.UploadFileAsync(s3Obj, cred);

            await _companyRepository.PutFile(id, result.FileUrl);

            return Ok(result);

        }
    }
}
