using System.Text.Json;

namespace Heartcore.Logic.ApiProviders
{
	public class ContentManagementApiProvider: IContentManagementApiProvider
	{
        public async Task<string?> CreateContentAsync<T>(T request)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.umbraco.io");
            httpClient.DefaultRequestHeaders.Add("Api-Key", "ji35X6iQezNiTqBonX5X");
            httpClient.DefaultRequestHeaders.Add("Api-Version", "2");
            httpClient.DefaultRequestHeaders.Add("Umb-Project-Alias", "alisas-amiable-otter");

            var response = await httpClient.PostAsJsonAsync("/content", request);

            var responseContent = await response.Content.ReadAsStringAsync();

            using JsonDocument document = JsonDocument.Parse(responseContent);
            var root = document.RootElement;

            if (root.TryGetProperty("_id", out JsonElement id))
            {
                return id.GetString();
            }

            return null;
        }
    }
}

