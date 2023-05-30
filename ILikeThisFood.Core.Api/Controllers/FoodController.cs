using Amazon.Runtime;
using ILikeThisFood.Domain.Entities;
using ILikeThisFood.Domain.InputModels.Company;
using ILikeThisFood.Domain.InputModels.Food;
using ILikeThisFood.Domain.Repositories;
using ILikeThisFood.Services.Storage.Contracts;
using ILikeThisFood.Services.Storage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ILikeThisFood.Core.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;

        public FoodController(
            IFoodRepository foodRepository,
            IStorageService storageService,
            IConfiguration configuration)
        {
            _foodRepository = foodRepository;
            _storageService = storageService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Food> foods = await _foodRepository.GetAllAsync();

            return Ok(foods);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            Food food = await _foodRepository.GetAsync(id);

            return Ok(food);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateFoodInputModel foodInputModel)
        {
            var food = new Food(foodInputModel.Name, foodInputModel.Description, foodInputModel.CompanyId, foodInputModel.Ingredients);

            await _foodRepository.CreateAsync(food);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateFoodInputModel foodInputModel)
        {
            var food = await _foodRepository.GetAsync(foodInputModel.Id);
            food.Update(foodInputModel.Name, foodInputModel.Description, foodInputModel.Ingredients);

            await _foodRepository.UpdateAsync(food);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _foodRepository.DeleteAsync(id);

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

            await _foodRepository.PutPhoto(id, result.FileUrl);

            return Ok(result);
        }
    }
}
