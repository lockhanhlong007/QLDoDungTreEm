using System.Collections.Generic;
using System.Web;

namespace QLDoDungTreEm.Areas.Admin.Models
{
    public class Picture
    {
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}