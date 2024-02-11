using API.Models;
using Client.Services;
using IdentityModel.Client;
using Microsoft.AspNetCore.Components;


namespace Client.Pages
{
    public partial class CoffeeShops
    {
        private List<CoffeeShopModel> Shops = new();
        [Inject] private HttpClient HttpClient {  get; set; }
        [Inject] private IConfiguration Config {  get; set; }
        [Inject] private ITokenService TokenService {  get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenService = await TokenService.GetToken("CoffeeAPI.read");
            HttpClient.SetBearerToken(tokenService.AccessToken); // binds token to the actual request

            var result = await HttpClient.GetAsync(Config["apiUrl"] + "/api/CoffeeShop");

            if (result.IsSuccessStatusCode)
            {
                Shops = await result.Content.ReadFromJsonAsync<List<CoffeeShopModel>>();
            }
        }
    }
}
