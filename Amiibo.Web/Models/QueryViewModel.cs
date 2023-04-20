using Amiibo.Models;

namespace Amiibo.Web.Models;

public class SearchViewModel
{
    public string Query { get; set; }
    public List<NintendoAmiibo> Results { get; set; }
}