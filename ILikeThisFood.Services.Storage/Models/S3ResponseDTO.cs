using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Services.Storage.Models
{
    public class S3ResponseDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string FileUrl { get; set; }
    }
}
