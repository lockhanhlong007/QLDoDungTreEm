using ModelsDungChung.DataAccessObject;
using QLDoDungTreEm.Common;
using System.Web.Mvc;

namespace QLDoDungTreEm.Areas.Admin.Controllers
{
    public class HomeController : KiemTraSessionController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexLogin()
        {
            var dao = new DataAccessObject();
            var tmp = Session[CommonConstants.USER_SESSION] as UserLogin;
            return View(dao.GetByID(tmp.UserName));
        }
    }
}