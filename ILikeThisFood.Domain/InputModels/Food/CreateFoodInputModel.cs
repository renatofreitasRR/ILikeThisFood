using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.InputModels.Food
{
    public class CreateFoodInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CompanyId { get; set; }
        public ICollection<string> Ingredients { get; set; } = new List<string>();
    }
}
