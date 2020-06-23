using ModelsDungChung;
using QLDoDungTreEm.Common;
using System.Linq;
using System.Web.Mvc;

namespace QLDoDungTreEm.Controllers
{
    public class HomeController : Controller
    {
        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        public ActionResult TrangChu()
        {
            if (Session[CommonConstants.PriceRanger_SESSION] != null)
            {
                Session.Remove(CommonConstants.PriceRanger_SESSION);
            }
            if (Session[CommonConstants.SORT_SESSION] != null)
            {
                Session.Remove(CommonConstants.SORT_SESSION);
            }
            if (Session[CommonConstants.IDPRODUCT_SESSION] != null)
            {
                Session.Remove(CommonConstants.IDPRODUCT_SESSION);
            }
            ViewBag.Slides = csdl.Slides.Where(x => x.status == true).OrderBy(x => x.DisplayOrder).ToList();
            ViewBag.NewProduct = csdl.SanPhams.OrderBy(x => x.CreatedDate).Take(3).ToList();
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _CategoriesLeft()
        {
            ViewBag.CategoriesLoaiSP = csdl.CategoryLoaiSP().ToList();
            return PartialView(csdl.CategoryDM().ToList());
        }

        [HttpPost]
        public ActionResult TimKiemSP(FormCollection tmp)
        {
            return View(csdl.SanPhams.ToList().FindAll(x => x.TenSP == tmp["txtSearch"]).ToList());
        }
    }
}