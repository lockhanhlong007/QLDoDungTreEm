using ModelsDungChung.DataAccessObject;
using QLDoDungTreEm.Areas.Admin.Models;
using QLDoDungTreEm.Common;
using System.Web.Mvc;

namespace QLDoDungTreEm.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult DangNhap()
        {
            return View();
        }

        public ActionResult XuLyLogin(Login model)
        {
            if (ModelState.IsValid)
            {
                var dao = new DataAccessObject();
                var result = dao.Login(model.UserName, FileMaHoa.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.GroupID = user.GroupID;
                    var listPermission = dao.GetListPermission(model.UserName);
                    Session.Add(CommonConstants.SESSION_PERMISSION, listPermission);
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (result == -1)
                    {
                        ModelState.AddModelError("", "Tài Khoản Không Tồn Tại!!!");
                    }
                    if (result == -2)
                    {
                        ModelState.AddModelError("", "Mật Khẩu Không Đúng!!!");
                    }
                }
            }
            return View("DangNhap");
        }

        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.USER_SESSION);
            return RedirectToAction("DangNhap", "Login");
        }
    }
}