﻿using Amazon.Runtime;
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
        const string bucketName = "ilikethisfoods3";

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
            var company = new Company(companyInputModel.Name, companyInputModel.RegistreNumber, null, companyInputModel.Address);

            await _companyRepository.CreateAsync(company);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateCompanyInputModel companyInputModel)
        {
            var company = await _companyRepository.GetAsync(companyInputModel.Id);
            company.Update(companyInputModel.Name, companyInputModel.RegistreNumber, companyInputModel.Address);

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
            var company = await _companyRepository.GetAsync(id);

            // Process file
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            // call server
            var s3Obj = new S3Object(file.FileName, memoryStream, bucketName);

            var cred = new AwsCredentials()
            {
                AccessKey = _configuration["AwsConfiguration:AWSAccessKey"],
                SecretKey = _configuration["AwsConfiguration:AWSSecretKey"]
            };

            var result = await _storageService.UploadFileAsync(s3Obj, cred, company.PhotoUrl);

            await _companyRepository.PutPhoto(id, result.FileUrl);

            return Ok(result);

        }
    }
}
