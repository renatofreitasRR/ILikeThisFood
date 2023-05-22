using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.Entities
{
    public class Company : BaseEntity
    {
        public Company(string name, string registreNumber, string? fileUrl)
        {
            Name = name;
            RegistreNumber = registreNumber;
            FileUrl = fileUrl;
        }

        public Company(string id, string name, string registreNumber, string? fileUrl)
        {
            Id = id;
            Name = name;
            RegistreNumber = registreNumber;
            FileUrl = fileUrl;
        }

        public string Name { get; private set; }
        public string RegistreNumber { get; private set; }
        public string? FileUrl { get; private set; }

        public void SetFileUrl(string fileUrl)
        {
            FileUrl = fileUrl;
        }
    }
}
