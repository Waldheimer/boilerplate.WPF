using System.Net.Http;
using System.Net.Http.Json;

namespace Apmt_WPF.Features.Users;

public class UserService
{
    private readonly HttpClient _httpClient;
    public UserService() 
    {
        this._httpClient = new HttpClient();
    }

    public async Task<string> RegisterUserAsync(UserRegisterDto user)
    {
        var url = $"https://localhost:8123/api/v1/users/register";

        var response = await _httpClient.PostAsJsonAsync(url, user);
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        return string.Empty;
    }
}
