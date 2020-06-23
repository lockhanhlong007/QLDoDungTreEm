using ModelsDungChung;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QLDoDungTreEm.Areas.Admin.Controllers
{
    public class ThuongHieuController : KiemTraSessionController
    {
        // GET: Admin/ThuongHieu
        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        // GET: Admin/DanhMuc
        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var layth = csdl.ThuongHieus.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                layth = layth.Where(x => x.TenThuongHieu.Contains(search)).ToList();
            }
            return View(layth.OrderBy(x => x.MaThuongHieu).ToPagedList(page, pageSize));
        }

        [HttpPost]
        public ActionResult XuLyCreate(ThuongHieu th)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    csdl.ThemThuongHieu(th.TenThuongHieu);
                    SetAlert("Add Successful", "success");
                    return RedirectToAction("Index", "ThuongHieu");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Add Failded");
                }
            }
            return View("Create");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var tmp = csdl.ThuongHieus.ToList().Find(x => x.MaThuongHieu == id);

            return View(tmp);
        }

        [HttpPost]
        public ActionResult Edit(ThuongHieu th)
        {
            try
            {
                csdl.CapNhatThuongHieu(th.MaThuongHieu, th.TenThuongHieu);
                SetAlert("Update Successful", "success");
            }
            catch (Exception)
            {
                SetAlert("Update Failed", "error");
            }
            return RedirectToAction("Index", "ThuongHieu");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var laytatcathulqdenth = csdl.SanPhams.Where(x => x.MaThuongHieu == id).ToList();
            if (laytatcathulqdenth.Count > 0)
            {
                csdl.SanPhams.DeleteAllOnSubmit(laytatcathulqdenth);
                csdl.SubmitChanges();
            }
            csdl.XoaThuongHieu(id);
            csdl.SubmitChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}