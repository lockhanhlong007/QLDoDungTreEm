using ModelsDungChung;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QLDoDungTreEm.Areas.Admin.Controllers
{
    public class LoaiSPController : KiemTraSessionController
    {
        // GET: Admin/LoaiSP
        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var laydm = csdl.LoaiSPs.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                laydm = laydm.Where(x => x.TenLoaiSP.Contains(search)).ToList();
            }
            return View(laydm.OrderBy(x => x.MaLoai).ToPagedList(page, pageSize));
        }

        [HttpPost]
        public ActionResult XuLyCreate(LoaiSP lsp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    csdl.ThemLoaiSanPham(lsp.MaDM, lsp.TenLoaiSP);
                    SetAlert("Add Successful", "success");
                    return RedirectToAction("Index", "LoaiSP");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Add Failded");
                }
            }
            SetViewBag();
            return View("Create");
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        public ActionResult Edit(int id)
        {
            var tmp = csdl.LoaiSPs.ToList().Find(x => x.MaLoai == id);
            SetViewBag(tmp.MaDM);
            return View(tmp);
        }

        [HttpPost]
        public ActionResult Edit(LoaiSP lsp)
        {
            try
            {
                csdl.CapNhatLoaiSanPham(lsp.MaLoai, lsp.MaDM, lsp.TenLoaiSP);
                SetAlert("Update Successful", "success");
            }
            catch (Exception)
            {
                SetAlert("Update Failed", "error");
            }
            SetViewBag(lsp.MaDM);
            return RedirectToAction("Index", "LoaiSP");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            csdl.XoaLoaiSanPham(id);
            csdl.SubmitChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        public void SetViewBag(int? selectedIDDM = null)
        {
            ViewBag.MaDM = new SelectList(csdl.DanhMucs.ToList().OrderBy(x => x.TenDM), "MaDM", "TenDM", selectedIDDM);
        }
    }
}