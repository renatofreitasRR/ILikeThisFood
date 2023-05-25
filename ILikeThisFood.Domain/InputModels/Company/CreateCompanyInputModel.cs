using ILikeThisFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.InputModels.Company
{
    public class CreateCompanyInputModel
    {
        public CreateCompanyInputModel()
        {
            Address = new Address();
        }

        public string Name { get; set; }
        public string RegistreNumber { get; set; }
        public Address Address { get; set; }
    }
}
