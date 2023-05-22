using ILikeThisFood.Services.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Services.Storage.Contracts
{
    public interface IStorageService
    {
        Task<S3ResponseDTO> UploadFileAsync(S3Object obj, AwsCredentials awsCredentialsValues);
    }
}
