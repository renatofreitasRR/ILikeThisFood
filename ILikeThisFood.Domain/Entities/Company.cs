using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.Entities
{
    public class Company : BaseEntity
    {
        public Company(string name, string registreNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            RegistreNumber = registreNumber;
        }

        public Company(Guid id, string name, string registreNumber)
        {
            Id = id;
            Name = name;
            RegistreNumber = registreNumber;
        }

        public string Name { get; private set; }
        public string RegistreNumber { get; private set; }
    }
}
