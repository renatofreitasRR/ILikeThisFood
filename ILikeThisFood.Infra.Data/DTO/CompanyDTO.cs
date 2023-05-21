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
        public CompanyDTO( string name, string registreNumber)
        {
            Name = name;
            RegistreNumber = registreNumber;
        }

        public CompanyDTO(string id, string name, string registreNumber)
        {
            Id = id;
            Name = name;
            RegistreNumber = registreNumber;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string RegistreNumber { get; set; }

        public void Update(string name, string registreNumber)
        {
            this.Name = name;
            this.RegistreNumber = registreNumber;
        }
    }
}
