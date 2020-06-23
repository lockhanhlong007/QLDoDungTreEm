using ModelsDungChung;
using QLDoDungTreEm.Common;
using QLDoDungTreEm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QLDoDungTreEm.Controllers
{
    public class ShopCartController : Controller
    {
        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        // GET: ShopCart
        public ActionResult Index()
        {
            var Cart = Session[CommonConstants.Cart_SESSION];
            var list = new List<CartItem>();
            if (Cart != null)
            {
                list = Cart as List<CartItem>;
            }
            return View(list);
        }

        public JsonResult Delete(string id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.Cart_SESSION];
            sessionCart.RemoveAll(x => x.Product.MaSP.Trim() == id.Trim());
            Session[CommonConstants.Cart_SESSION] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstants.Cart_SESSION];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.FirstOrDefault(x => x.Product.MaSP == item.Product.MaSP.Trim());
                if (jsonItem != null)
                {
                    item.quantity = jsonItem.quantity;
                }
            }
            Session[CommonConstants.Cart_SESSION] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public ActionResult Payment(string HoTen, string DienThoai, string DiaChi, string Email)
        {
            if (csdl.KhachHangs.ToList().Exists(x => x.HoTen.Trim() == HoTen.Trim() && x.DienThoai.Trim() == DienThoai.Trim()) == false)
            {
                KhachHang kh = new KhachHang();
                kh.HoTen = HoTen;
                kh.DiaChi = DiaChi;
                kh.Email = Email;
                kh.DienThoai = DienThoai;
                csdl.KhachHangs.InsertOnSubmit(kh);
                csdl.SubmitChanges();
            }
            var DetailCustomer = csdl.KhachHangs.FirstOrDefault(x => x.HoTen.Trim() == HoTen.Trim() && x.DienThoai.Trim() == DienThoai.Trim());
            DonHang NewOrder = new DonHang();
            NewOrder.MaKH = DetailCustomer.MaKH;
            NewOrder.NgayDat = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            NewOrder.NgayGiao = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            NewOrder.TinhTrangGiaoHang = false;
            NewOrder.DaThanhToan = false;
            csdl.DonHangs.InsertOnSubmit(NewOrder);
            csdl.SubmitChanges();
            var ListCart = Session[CommonConstants.Cart_SESSION] as List<CartItem>;
            try
            {
                foreach (var item in ListCart)
                {
                    CTDonHang ct = new CTDonHang();
                    ct.MaSP = item.Product.MaSP;
                    ct.MaDH = NewOrder.MaDH;
                    ct.SoLuong = item.quantity;
                    ct.DonGia = item.Product.GiaBan * item.quantity;
                    csdl.CTDonHangs.InsertOnSubmit(ct);
                    csdl.SubmitChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Redirect("Success");
        }

        public ActionResult ThemGioHang(string productID, int quantity)
        {
            SanPham ViewDetail = csdl.SanPhams.FirstOrDefault(x => x.MaSP.Equals(productID));
            var Cart = Session[CommonConstants.Cart_SESSION];
            if (Cart != null)
            {
                var list = Cart as List<CartItem>;
                if (list.Exists(x => x.Product.MaSP.Trim() == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.MaSP.Trim() == productID)
                        {
                            item.quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = ViewDetail;
                    item.quantity = quantity;
                    list.Add(item);
                }
                Session[CommonConstants.Cart_SESSION] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = ViewDetail;
                item.quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);

                Session[CommonConstants.Cart_SESSION] = list;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}