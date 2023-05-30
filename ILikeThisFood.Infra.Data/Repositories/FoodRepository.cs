using ILikeThisFood.Domain.Entities;
using ILikeThisFood.Domain.Repositories;
using ILikeThisFood.Infra.Data.Context;
using ILikeThisFood.Infra.Data.DTO;
using MongoDB.Driver;

namespace ILikeThisFood.Infra.Data.Repositories
{
    public class FoodRepository : DataContext, IFoodRepository
    {
        private readonly IMongoCollection<FoodDTO> _foodsCollection;

        public FoodRepository() : base("Foods")
        {
            _foodsCollection = this._mongoDatabase.GetCollection<FoodDTO>(this._collectionName);
        }

        public async Task CreateAsync(Food food)
        {
            var foodDTO = FoodDTO.Create(food.Name, food.Description, food.CompanyId, food.Ingredients);

            await _foodsCollection.InsertOneAsync(foodDTO);
        }

        public async Task DeleteAsync(string id)
        {
            await _foodsCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            var foodsDTO = await _foodsCollection
                .Find(_ => true)
                .ToListAsync();

            var foods = foodsDTO.Select(x => new Food(x.Id, x.Name, x.Description, x.CompanyId, x.Ingredients, x.PhotoUrl));

            return foods;
        }

        public async Task<Food> GetAsync(string id)
        {
            var foodDTO = await _foodsCollection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (foodDTO is null)
                throw new Exception();

            var Food = new Food(foodDTO.Id, foodDTO.Name, foodDTO.Description, foodDTO.CompanyId, foodDTO.Ingredients, foodDTO.PhotoUrl);

            return Food;
        }

        public async Task PutPhoto(string id, string photoUrl)
        {
            var food = await this.GetAsync(id);
            food.SetPhotoUrl(photoUrl);

            await this.UpdateAsync(food);
        }

        public async Task UpdateAsync(Food food)
        {
            var foodDTO = FoodDTO.Update(food.Id, food.Name, food.Description, food.CompanyId, food.Ingredients, food.PhotoUrl);

            await _foodsCollection.ReplaceOneAsync(x => x.Id == food.Id.ToString(), foodDTO);
        }
    }
}
