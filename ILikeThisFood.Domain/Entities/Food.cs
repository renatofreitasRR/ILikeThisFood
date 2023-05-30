using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.Entities
{
    public class Food : BaseEntity
    {
        public Food(string id, string name, string description, string companyId, ICollection<string> ingredients, string photoUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            CompanyId = companyId;
            PhotoUrl = photoUrl;
        }

        public Food(string name, string description, string companyId, ICollection<string> ingredients)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            CompanyId = companyId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string PhotoUrl { get; private set; }
        public string CompanyId { get; private set; }
        public ICollection<string> Ingredients { get; private set; }

        public void Update(string name, string description, ICollection<string> ingredients)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
        }

        public void SetPhotoUrl(string photoUrl)
        {
            PhotoUrl = photoUrl;
        }
    }
}
