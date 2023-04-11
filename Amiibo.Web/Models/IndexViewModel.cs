using System.Collections.Generic;
using Amiibo.Models;

namespace Amiibo.Web.Models
{
    public class IndexViewModel
    {
        public List<NintendoAmiibo> Amiibos { get; set; } = new List<NintendoAmiibo>();
    }
}