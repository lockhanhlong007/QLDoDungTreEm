using BotDetect.Web.Mvc;
using ModelsDungChung;
using ModelsDungChung.DataAccessObject;
using QLDoDungTreEm.Common;
using QLDoDungTreEm.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QLDoDungTreEm.Controllers
{
    public class CustomerController : Controller
    {
        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        // GET: Customer
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var dao = new DataAccessObject();
                var result = dao.LoginKH(model.TaiKhoan, FileMaHoa.MD5Hash(model.MatKhau));
                if (result == 1)
                {
                    var khachHang = dao.GetByID_KH(model.TaiKhoan);
                    Session.Add(CommonConstants.CUSTOMER_SESSION, khachHang.HoTen);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài Khoản Không Tồn Tại!!!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật Khẩu Không Đúng!!!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài Khoản Đã Bị Khóa!!!");
                }
                model = new Login();
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.CUSTOMER_SESSION);
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "registerCapcha", "Incorrect CAPTCHA code!")]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (csdl.KhachHangs.ToList().Exists(x => x.TaiKhoan.Trim() == model.TaiKhoan.Trim()))
                    {
                        ModelState.AddModelError("", "UserName already exists");
                    }
                    else if (csdl.KhachHangs.ToList().Exists(x => x.Email.Trim() == model.Email.Trim()))
                    {
                        ModelState.AddModelError("", "Email already exists");
                    }
                    else if (csdl.KhachHangs.ToList().Exists(x => x.DienThoai.Trim() == model.DienThoai.Trim()))
                    {
                        ModelState.AddModelError("", "Phone Numeber already exists");
                    }
                    else
                    {
                        KhachHang kh = new KhachHang();
                        kh.HoTen = model.HoTen;
                        kh.GioiTinh = model.GioiTinh.ToString();
                        kh.TaiKhoan = model.TaiKhoan;
                        kh.MatKhau = FileMaHoa.MD5Hash(model.MatKhau);
                        kh.NgaySinh = model.NgaySinh;
                        kh.DiaChi = model.DiaChi;
                        kh.DienThoai = model.DienThoai;
                        kh.Email = model.Email;
                        kh.Status = true;
                        csdl.KhachHangs.InsertOnSubmit(kh);
                        csdl.SubmitChanges();
                        ViewBag.Success = "Registered Successfully";
                        model = new Register();
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Registered Failed");
                }
            }

            return View(model);
        }
    }
}