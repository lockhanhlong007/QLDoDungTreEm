using ModelsDungChung;
using PagedList;
using QLDoDungTreEm.Common;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QLDoDungTreEm.Areas.Admin.Controllers
{
    public class KhachHangController : KiemTraSessionController
    {
        // GET: Admin/KhachHang
        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var laynv = csdl.KhachHangs.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                laynv = laynv.Where(x => x.TaiKhoan.Contains(search) || x.HoTen.Contains(search)).ToList();
            }
            return View(laynv.OrderBy(x => x.MaKH).ToPagedList(page, pageSize));
        }

        [HttpPost]
        public ActionResult XuLyCreate(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mahoa = FileMaHoa.MD5Hash(kh.MatKhau);
                    kh.MatKhau = mahoa;
                    csdl.KhachHangs.InsertOnSubmit(kh);
                    csdl.SubmitChanges();
                    SetAlert("Add Successful", "success");
                    return RedirectToAction("Index", "KhachHang");
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
            var tmp = csdl.KhachHangs.ToList().Find(x => x.MaKH == id);
            return View(tmp);
        }

        [HttpPost]
        public ActionResult Edit(KhachHang kh)
        {
            try
            {
                var tmp = csdl.KhachHangs.ToList().SingleOrDefault(x => x.MaKH == kh.MaKH);
                tmp.NgaySinh = kh.NgaySinh;
                tmp.HoTen = kh.HoTen;
                if (!string.IsNullOrEmpty(kh.MatKhau))
                {
                    tmp.MatKhau = FileMaHoa.MD5Hash(kh.MatKhau);
                }
                tmp.DiaChi = kh.DiaChi;
                tmp.DienThoai = kh.DienThoai;
                tmp.Email = kh.Email;
                csdl.SubmitChanges();
                SetAlert("Update Successful", "success");
            }
            catch (Exception)
            {
                SetAlert("Update Failed", "error");
            }
            return RedirectToAction("Index", "KhachHang");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var kiemtralqdenKH = csdl.DonHangs.Where(x => x.MaKH == id).ToList();
            if (kiemtralqdenKH.Count > 0)
            {
                csdl.DonHangs.DeleteAllOnSubmit(kiemtralqdenKH);
                csdl.SubmitChanges();
            }
            var tmp = csdl.KhachHangs.ToList().Find(x => x.MaKH == id);
            csdl.KhachHangs.DeleteOnSubmit(tmp);
            csdl.SubmitChanges();

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var tmp = csdl.KhachHangs.FirstOrDefault(x => x.MaKH == id);
            tmp.Status = !tmp.Status;
            csdl.ChangeStatus_KhachHang(tmp.MaKH, tmp.Status);
            return Json(new
            {
                status = tmp.Status
            });
        }
    }
}