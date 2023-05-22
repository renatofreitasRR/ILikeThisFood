using Amazon.Runtime;
using Amazon.S3.Transfer;
using Amazon.S3;
using ILikeThisFood.Services.Storage.Contracts;
using ILikeThisFood.Services.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Services.Storage.Services
{
    public class StorageService : IStorageService
    {

        public StorageService()
        {
        }

        public async Task<S3ResponseDTO> UploadFileAsync(S3Object obj, AwsCredentials awsCredentialsValues)
        {
            var credentials = new BasicAWSCredentials(awsCredentialsValues.AccessKey, awsCredentialsValues.SecretKey);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            var response = new S3ResponseDTO();
            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = obj.InputStream,
                    Key = obj.Name,
                    BucketName = obj.BucketName,
                    CannedACL = S3CannedACL.NoACL
                };

                // initialise client
                using var client = new AmazonS3Client(credentials, config);

                // initialise the transfer/upload tools
                var transferUtility = new TransferUtility(client);

                // initiate the file upload
               await transferUtility.UploadAsync(uploadRequest);

                var urlRequest = new Amazon.S3.Model.GetPreSignedUrlRequest
                {
                    BucketName = obj.BucketName,
                    Key = obj.Name,
                    Expires = DateTime.UtcNow.AddMinutes(60) // Set the expiration time as per your requirements
                };

                var url = client.GetPreSignedURL(urlRequest);

                response.StatusCode = 201;
                response.Message = $"{obj.Name} has been uploaded sucessfully";
                response.FileUrl = url;
            }
            catch (AmazonS3Exception s3Ex)
            {
                response.StatusCode = (int)s3Ex.StatusCode;
                response.Message = s3Ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
