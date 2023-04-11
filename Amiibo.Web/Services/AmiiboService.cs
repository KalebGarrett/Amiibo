using System.Text.Json;
using Amiibo.Models;

namespace Amiibo.Web.Services
{
    public class AmiiboService
    {
        public async Task<List<NintendoAmiibo>> GetAll()
        {
            using var client = new HttpClient();
            var result = await client.GetAsync("https://www.amiiboapi.com/api/amiibo/");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                JsonSerializer.Deserialize<Root>(json);
                return Root.NintendoAmiibos;
            }

            return new List<NintendoAmiibo>();
        }
    }
}