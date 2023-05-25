using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.Entities
{
    public class Company : BaseEntity
    {
        public Company(string id, string name, string registreNumber, string? photoUrl, Address address)
        {
            Id = id;
            Name = name;
            RegistreNumber = registreNumber;
            PhotoUrl = photoUrl;
            Address = address;
        }
        public Company(string name, string registreNumber, string? photoUrl, Address address)
        {
            Name = name;
            RegistreNumber = registreNumber;
            PhotoUrl = photoUrl;
            Address = address;

            SetCreatedAt();
            SetUpdatedAt();
        }

        public string Name { get; private set; }
        public string RegistreNumber { get; private set; }
        public string? PhotoUrl { get; private set; }
        public Address Address { get; private set; }

        public void SetPhotoUrl(string photoUrl)
        {
            PhotoUrl = photoUrl;
            SetUpdatedAt();
        }

        public void Update(string name, string registreNumber, Address address)
        {
            Name = name;
            RegistreNumber = registreNumber;
            Address = address;
            SetUpdatedAt();
        }

        private void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetCreatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
