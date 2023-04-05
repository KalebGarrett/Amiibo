using System.Collections.Generic;
using Amiibo.Models;

namespace Amiibo.Web.Models
{
    public class IndexViewModel
    {
        public List<NintendoAmiibos> Amiibos { get; set; } = new List<NintendoAmiibos>();
    }
}