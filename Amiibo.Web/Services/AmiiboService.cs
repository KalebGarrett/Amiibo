using System.Text.Json;
using Amiibo.Models;

namespace Amiibo.Web.Services
{
    public class AmiiboService
    {
        public async Task<List<NintendoAmiibos>> GetAll()
        {
            using var client = new HttpClient();
            var result = await client.GetAsync("https://www.amiiboapi.com/api/amiibo/");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<NintendoAmiibos>>(json);
            }

            return new List<NintendoAmiibos>();
        }
    }
}