using ModelsDungChung;
using PagedList;
using QLDoDungTreEm.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QLDoDungTreEm.Areas.Admin.Controllers
{
    public class DonHangController : KiemTraSessionController
    {
        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        // GET: Admin/DonHang
        public ActionResult IndexDH(string search, int page = 1, int pageSize = 5)
        {
            List<LayHoaDonResult> laydh = csdl.LayHoaDon().ToList();
            if (!string.IsNullOrEmpty(search))
            {
                laydh = laydh.Where(x => x.HoTen.Contains(search) || x.NgayDat.ToShortDateString().Equals(search) || x.NgayGiao.Value.ToShortDateString() == search).ToList();
            }
            return View(laydh.OrderBy(x => x.MaDH).ToPagedList(page, pageSize));
        }

        public ActionResult IndexCTDH(string search, int page = 1, int pageSize = 5)
        {
            List<LayChiTietHoaDonResult> layctdh = csdl.LayChiTietHoaDon(int.Parse(Session[CommonConstants.CTHOADON_SESSION].ToString())).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                layctdh = layctdh.Where(x => x.TenSP.Contains(search)).ToList();
            }
            return View(layctdh.OrderBy(x => x.MaDH).ToPagedList(page, pageSize));
        }

        public ActionResult luuSession(int id)
        {
            Session.Add(CommonConstants.CTHOADON_SESSION, id);
            return RedirectToAction("IndexCTDH", "DonHang");
        }

        [HttpDelete]
        public ActionResult Delete(int MaDH)
        {
            var xoatatcathulqdensp = csdl.CTDonHangs.Where(x => x.MaDH == MaDH).ToList();
            if (xoatatcathulqdensp.Count > 0)
            {
                csdl.CTDonHangs.DeleteAllOnSubmit(xoatatcathulqdensp);
                csdl.SubmitChanges();
            }
            csdl.XoaHoaDon(MaDH);
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public JsonResult ChangeTinhTrangGiao(int id)
        {
            var tmp = csdl.DonHangs.FirstOrDefault(x => x.MaDH == id);
            tmp.TinhTrangGiaoHang = !tmp.TinhTrangGiaoHang;
            csdl.ChangeTinhTrangGiao(tmp.MaDH, tmp.TinhTrangGiaoHang, tmp.DaThanhToan);
            return Json(new
            {
                TinhTrangGiaoHang = tmp.TinhTrangGiaoHang,
                ThanhToan = tmp.DaThanhToan
            });
        }
    }
}