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
        public CompanyDTO(Guid id, string name, string registreNumber)
        {
            Id = id;
            Name = name;
            RegistreNumber = registreNumber;
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RegistreNumber { get; set; }
    }
}
