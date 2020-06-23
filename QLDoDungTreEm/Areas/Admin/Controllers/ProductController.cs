using ModelsDungChung;
using PagedList;
using QLDoDungTreEm.Areas.Admin.Models;
using QLDoDungTreEm.Common;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace QLDoDungTreEm.Areas.Admin.Controllers
{
    public class ProductController : KiemTraSessionController
    {
        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        // GET: Admin/Product

        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var laysp = csdl.SanPhams.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                laysp = laysp.Where(x => x.TenSP.Contains(search) || x.MaSP.Contains(search)).ToList();
            }
            return View(laysp.OrderBy(x => x.MaSP).ToPagedList(page, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XuLyCreate(SanPham sp, Picture picture)
        {
            if (ModelState.IsValid)
            {
                string luufile = "";
                try
                {
                    if (picture.Files.ToList()[0] != null)
                    {
                        foreach (var item in picture.Files)
                        {
                            if (!string.IsNullOrEmpty(luufile))
                            {
                                luufile = luufile + "|";
                            }
                            var filename = Path.GetFileName(item.FileName);
                            luufile = luufile + filename;
                            var path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Hinh/"), filename);
                            if (!System.IO.File.Exists(path))
                            {
                                item.SaveAs(path);
                            }
                        }
                    }
                    sp.Hinh = luufile;
                    sp.CreatedDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    csdl.ThemSanPham(sp.MaSP, sp.MaThuongHieu, sp.MaLoai, sp.Hinh, sp.GiaBan, sp.NhaSanXuat, sp.XuatXu, sp.DungTich, sp.ChatLieu, sp.DoiTuong, sp.TenSP, sp.CreatedDate, sp.Description);
                    SetAlert("Add Successful", "success");
                    return RedirectToAction("Index", "Product");
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
        public ActionResult Edit(string id)
        {
            var getsp = csdl.SanPhams.FirstOrDefault(x => x.MaSP == id.Trim());
            Session.Add(CommonConstants.SAVEIMAGE_SESSION, getsp.Hinh);
            SetViewBag(getsp.MaLoai, getsp.MaThuongHieu);
            return View(getsp);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham sp, Picture picture)
        {
            string luufile = "";
            try
            {
                if (picture.Files.ToList()[0] != null)
                {
                    foreach (var item in picture.Files)
                    {
                        if (!string.IsNullOrEmpty(luufile))
                        {
                            luufile = luufile + "|";
                        }
                        var filename = Path.GetFileName(item.FileName);
                        luufile = luufile + filename;
                        var path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Hinh/"), filename);
                        if (!System.IO.File.Exists(path))
                        {
                            item.SaveAs(path);
                        }
                    }
                    sp.Hinh = luufile;
                }
                else
                {
                    sp.Hinh = Session[CommonConstants.SAVEIMAGE_SESSION].ToString();
                }
                Session.Remove(CommonConstants.SAVEIMAGE_SESSION);
                csdl.CapNhatSP(sp.MaSP, sp.MaThuongHieu, sp.MaLoai, sp.TenSP, sp.Hinh, sp.GiaBan, sp.NhaSanXuat, sp.XuatXu, sp.DungTich, sp.ChatLieu, sp.DoiTuong, sp.Description);
                SetAlert("Update Successful", "success");
            }
            catch (Exception)
            {
                SetAlert("Update Failed", "error");
            }
            SetViewBag(sp.MaLoai, sp.MaThuongHieu);
            return RedirectToAction("Index", "Product");
        }

        [HttpDelete]
        public ActionResult Delete(string MaSP)
        {
            var xoatatcathulqdensp = csdl.CTDonHangs.Where(x => x.MaSP == MaSP.Trim()).ToList();
            if (xoatatcathulqdensp.Count > 0)
            {
                csdl.CTDonHangs.DeleteAllOnSubmit(xoatatcathulqdensp);
                csdl.SubmitChanges();
            }
            csdl.XoaSanPham(MaSP.Trim());
            return RedirectToAction("Index", "Product");
        }

        public void SetViewBag(int? selectedIDLoai = null, int? selectIDThuongHieu = null)
        {
            ViewBag.MaLoai = new SelectList(csdl.LoaiSPs.ToList().OrderBy(x => x.TenLoaiSP), "MaLoai", "TenLoaiSP", selectedIDLoai);
            ViewBag.MaThuongHieu = new SelectList(csdl.ThuongHieus.ToList().OrderBy(x => x.TenThuongHieu), "MaThuongHieu", "TenThuongHieu", selectIDThuongHieu);
        }
    }
}