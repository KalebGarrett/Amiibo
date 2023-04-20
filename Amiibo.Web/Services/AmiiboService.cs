using System.Security.Cryptography;
using System.Text.Json;
using Amiibo.Models;


namespace Amiibo.Web.Services
{
    public class AmiiboService
    {
        public List<NintendoAmiibo> NintendoAmiibos { get; set; } = null;
        public async Task<List<NintendoAmiibo>> GetAll()
        {
            if (NintendoAmiibos != null)
            {
                return NintendoAmiibos;
            }
            
            using var client = new HttpClient();
            var result = await client.GetAsync("https://www.amiiboapi.com/api/amiibo/");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                var root = JsonSerializer.Deserialize<Root>(json);
                NintendoAmiibos = root.NintendoAmiibos;
                return NintendoAmiibos;
            }

            return new List<NintendoAmiibo>();
        }

        public async Task<NintendoAmiibo> Get(string id)
        {
            if (NintendoAmiibos == null)
            {
                await GetAll();
            }

            var amiibo = NintendoAmiibos.FirstOrDefault(x => x.Id.ToLower() == id.ToLower());
            return amiibo;
        }

        public async Task<List<NintendoAmiibo>> Query(string query)
        {
            if (NintendoAmiibos == null)
            {
                await GetAll();
            }

            var amiibos = NintendoAmiibos.Where(x => x.Name.ToLower().Contains(query.ToLower()));
            return amiibos.ToList();
        }

    }
}

