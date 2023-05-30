using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Infra.Data.DTO
{
    public class FoodDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string CompanyId { get; set; }
        public ICollection<string> Ingredients { get; set; }

        public static FoodDTO Create(string name, string description, string companyId, ICollection<string> ingredients)
        {
            var dto = new FoodDTO
            {
                Name = name,
                Description = description,
                CompanyId = companyId,
                Ingredients = ingredients
            };

            return dto;
        }

        public static FoodDTO Update(string id, string name, string description, string companyId, ICollection<string> ingredients, string photoUrl)
        {
            var dto = new FoodDTO
            {
                Id = id,
                Name = name,
                Description = description,
                CompanyId = companyId,
                Ingredients = ingredients,
                PhotoUrl = photoUrl
            };

            return dto;
        }
    }
}
