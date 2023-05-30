using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Services.Storage.Models
{
    public class S3Object
    {
        public S3Object(string fileName, MemoryStream inputStream, string bucketName)
        {
            var fileExt = Path.GetExtension(fileName);
            var docName = $"{Guid.NewGuid()}{fileExt}";

            Name = docName;
            InputStream = inputStream;
            BucketName = bucketName;
        }

        public string Name { get; private set; } = null!;
        public MemoryStream InputStream { get; private set; } = null!;
        public string BucketName { get; private set; } = null!;
    }
}
