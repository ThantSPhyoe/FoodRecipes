namespace FoodRecipe.Service
{
    public interface IMinioService
    {
        Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);

        Task<string> GetPresingedUrlAsync(string objectName, int expiryInSeconds = 3600);

        Task DeteteAsync(string objectName);
    }
}
