using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.Entities
{
    public class Company : BaseEntity
    {
        public Company(string id, string name, string registreNumber, string? fileUrl)
        {
            Id = id;
            Name = name;
            RegistreNumber = registreNumber;
            PhotoUrl = fileUrl;
        }
        public Company(string name, string registreNumber, string? fileUrl)
        {
            Name = name;
            RegistreNumber = registreNumber;
            PhotoUrl = fileUrl;
        }
       

        public string Name { get; private set; }
        public string RegistreNumber { get; private set; }
        public string? PhotoUrl { get; private set; }
        public IEnumerable<Food> Foods { get; private set; } = Enumerable.Empty<Food>();

        public void SetPhotoUrl(string photoUrl)
        {
            PhotoUrl = photoUrl;
        }
    }
}
