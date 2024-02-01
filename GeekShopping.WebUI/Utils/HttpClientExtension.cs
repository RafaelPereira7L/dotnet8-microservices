using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace GeekShopping.WebUI.Utils;

public static class HttpClientExtension
{
    private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");
    private static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    public static async Task<T> GetAsync<T>(this HttpResponseMessage responseMessage)
    {
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new ApplicationException("Error while fetching data: "+ responseMessage.ReasonPhrase);
        }

        var responseString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        return JsonSerializer.Deserialize<T>(responseString,
            jsonSerializerOptions) ?? throw new ApplicationException("Error while deserializing data");
    }
    
    public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient httpClient, string url, T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = contentType;
        return httpClient.PostAsync(url, content);
    }
    
    public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);
        Console.WriteLine(dataAsString);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = contentType;
        return httpClient.PutAsync(url, content);
    }
    
    public static Task<HttpResponseMessage> Delete(this HttpClient httpClient, string url)
    {
        return httpClient.DeleteAsync(url);
    }
}