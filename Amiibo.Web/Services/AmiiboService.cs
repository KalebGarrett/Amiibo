using System.Text.Json;
using Amiibo.Models;

namespace Amiibo.Web.Services
{
    public class AmiiboService
    {
        public List<NintendoAmiibos> Amiibos { get; set; } = null;

        public async Task<List<NintendoAmiibos>> GetAll()
        {
            if (Amiibos != null)
            {
                return Amiibos;
            }
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
//var dictionary = JsonSerializer.Deserialize<Dictionary<string, NintendoAmiibos>>(json);
//return dictionary.Values.ToList();