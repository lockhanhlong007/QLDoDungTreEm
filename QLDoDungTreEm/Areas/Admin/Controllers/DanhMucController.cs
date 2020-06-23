using ModelsDungChung;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QLDoDungTreEm.Areas.Admin.Controllers
{
    public class DanhMucController : KiemTraSessionController
    {
        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        // GET: Admin/DanhMuc
        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var laydm = csdl.DanhMucs.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                laydm = laydm.Where(x => x.TenDM.Contains(search)).ToList();
            }
            return View(laydm.OrderBy(x => x.MaDM).ToPagedList(page, pageSize));
        }

        [HttpPost]
        public ActionResult XuLyCreate(DanhMuc dm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    csdl.ThemDanhMuc(dm.TenDM);
                    SetAlert("Add Successful", "success");
                    return RedirectToAction("Index", "DanhMuc");
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
            var tmp = csdl.DanhMucs.ToList().Find(x => x.MaDM == id);
            return View(tmp);
        }

        [HttpPost]
        public ActionResult Edit(DanhMuc dm)
        {
            try
            {
                csdl.CapNhatDanhMuc(dm.MaDM, dm.TenDM);
                SetAlert("Update Successful", "success");
            }
            catch (Exception)
            {
                SetAlert("Update Failed", "error");
            }
            return RedirectToAction("Index", "DanhMuc");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var laytatcathulqdendm = csdl.LoaiSPs.Where(x => x.MaDM == id).ToList();
            if (laytatcathulqdendm.Count > 0)
            {
                csdl.LoaiSPs.DeleteAllOnSubmit(laytatcathulqdendm);
                csdl.SubmitChanges();
            }
            csdl.XoaDanhMuc(id);
            csdl.SubmitChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}