using ModelsDungChung;
using PagedList;
using QLDoDungTreEm.Common;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QLDoDungTreEm.Areas.Admin.Controllers
{
    public class AdminController : KiemTraSessionController
    {
        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        // GET: Admin/Admin
        [HasPermission(RoleID = "VIEW_MANAGER")]
        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var laynv = csdl.Managers.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                laynv = laynv.Where(x => x.UserName.Contains(search) || x.Name.Contains(search)).ToList();
            }
            return View(laynv.OrderBy(x => x.ID).ToPagedList(page, pageSize));
        }

        [HttpPost]
        [HasPermission(RoleID = "ADD_MANAGER")]
        public ActionResult XuLyCreate(Manager nv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mahoa = FileMaHoa.MD5Hash(nv.Password);
                    nv.Password = mahoa;
                    csdl.Managers.InsertOnSubmit(nv);
                    csdl.SubmitChanges();
                    SetAlert("Add Successful", "success");
                    return RedirectToAction("Index", "Admin");
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
        [HasPermission(RoleID = "ADD_MANAGER")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpGet]
        [HasPermission(RoleID = "EDIT_MANAGER")]
        public ActionResult Edit(int id)
        {
            var tmp = csdl.Managers.ToList().Find(x => x.ID == id);
            SetViewBag(tmp.GroupID);
            return View(tmp);
        }

        [HttpPost]
        [HasPermission(RoleID = "EDIT_MANAGER")]
        public ActionResult Edit(Manager nv)
        {
            try
            {
                var tmp = csdl.Managers.ToList().SingleOrDefault(x => x.ID == nv.ID);
                tmp.Name = nv.Name;
                if (!string.IsNullOrEmpty(nv.Password))
                {
                    tmp.Password = FileMaHoa.MD5Hash(nv.Password);
                }
                tmp.Address = nv.Address;
                tmp.Phone = nv.Phone;
                tmp.Email = nv.Email;
                tmp.GroupID = nv.GroupID;
                csdl.SubmitChanges();
                SetAlert("Update Successful", "success");
            }
            catch (Exception)
            {
                SetAlert("Update Failed", "error");
            }
            SetViewBag(nv.GroupID);
            return RedirectToAction("Index", "Admin");
        }

        public void SetViewBag(string selectedGroupID = null)
        {
            ViewBag.GroupID = new SelectList(csdl.ManagerGroups.ToList(), "ID_Group", "Name", selectedGroupID);
        }

        [HttpDelete]
        [HasPermission(RoleID = "DELETE_MANAGER")]
        public ActionResult Delete(int id)
        {
            var tmp = csdl.Managers.ToList().Find(x => x.ID == id);
            csdl.Managers.DeleteOnSubmit(tmp);
            csdl.SubmitChanges();

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}