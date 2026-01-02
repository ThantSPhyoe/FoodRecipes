using FoodRecipe.Utils.CustomExeptionHandling;
using Minio.DataModel.Args;
using Minio;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace FoodRecipe.Service
{
    public class MinioService : IMinioService
    {
        private readonly IMinioClient _minio;
        private readonly string _bucket;

        public MinioService(IConfiguration config)
        {
            try
            {
                var endpoint = config["MINIO_ENDPOINT"];
                var accessKey = config["MINIO_ACCESS_KEY"];
                var secretKey = config["MINIO_SECRET_KEY"];
                var bucket = config["MINIO_BUCKET"];
                var useSsl = bool.Parse(config["MINIO_USE_SSL"] ?? "false");

                if (string.IsNullOrWhiteSpace(endpoint) ||
                    string.IsNullOrWhiteSpace(accessKey) ||
                    string.IsNullOrWhiteSpace(secretKey) ||
                    string.IsNullOrWhiteSpace(bucket))
                {
                    throw new MinioException("MinIO environment variables are missing.");
                }

                _bucket = bucket;

                _minio = new MinioClient()
                    .WithEndpoint(endpoint)
                    .WithCredentials(accessKey, secretKey)
                    .WithSSL(useSsl)
                    .Build();
            }
            catch (Exception ex)
            {
                throw new MinioException("Failed to initialize MinIO client.", ex);
            }
        }

        public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType)
        {
            try
            {
                await EnsureBucketExists();

                var objectName = $"{Guid.NewGuid()}-{fileName}";
                await _minio.PutObjectAsync(
                    new PutObjectArgs()
                        .WithBucket(_bucket)
                        .WithObject(objectName)
                        .WithStreamData(fileStream)
                        .WithObjectSize(fileStream.Length)
                        .WithContentType(contentType)
                );

                return objectName;
            }catch(Exception ex)
            {
                throw new MinioException("Failed to upload file.", ex);
            }
        }

        public async Task<string> GetPresingedUrlAsync(string objectName, int expiryInSeconds = 3600)
        {
            try
            {
                return await _minio.PresignedGetObjectAsync(
                    new PresignedGetObjectArgs()
                        .WithBucket(_bucket)
                        .WithObject(objectName)
                        .WithExpiry(expiryInSeconds)
                    );
            }
            catch (Exception ex)
            {
                throw new MinioException("failed to deltee object.", ex);
            }
        }

        public async Task DeteteAsync(string objectName)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new MinioException("failed to deltee object.", ex);
            }
        }


        private async Task EnsureBucketExists()
        {
            var exists = await _minio.BucketExistsAsync(
                new BucketExistsArgs().WithBucket(_bucket)
                );

            if(!exists)
            {
                await _minio.MakeBucketAsync(
                    new MakeBucketArgs().WithBucket(_bucket)
                );
            }
        }



    }
}
