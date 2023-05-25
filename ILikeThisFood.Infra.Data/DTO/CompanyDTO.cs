using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Infra.Data.DTO
{
    public class CompanyDTO
    {
        public CompanyDTO(string name, string registreNumber, string? photoUrl)
        {
            Name = name;
            RegistreNumber = registreNumber;
            PhotoUrl = photoUrl;
        }

        public CompanyDTO(string id, string name, string registreNumber, string? photoUrl)
        {
            Id = id;
            Name = name;
            RegistreNumber = registreNumber;
            PhotoUrl = photoUrl;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string RegistreNumber { get; set; }
        public string? PhotoUrl { get; set; }

        public void Update(string name, string registreNumber)
        {
            this.Name = name;
            this.RegistreNumber = registreNumber;
        }
    }
}
