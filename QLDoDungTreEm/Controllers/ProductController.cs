using ModelsDungChung;
using PagedList;
using QLDoDungTreEm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QLDoDungTreEm.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ListProduct(string id, int page = 1, int pageSize = 9, bool checkfilter = false)
        {
            ViewBag.selectfilter = true;
            if (Session[CommonConstants.PriceRanger_SESSION] != null && checkfilter)
            {
                Session.Remove(CommonConstants.PriceRanger_SESSION);
            }
            if (Session[CommonConstants.SORT_SESSION] != null && checkfilter)
            {
                Session.Remove(CommonConstants.SORT_SESSION);
            }
            if (Session[CommonConstants.PriceRanger_SESSION] != null)
            {
                var tmp = Session[CommonConstants.PriceRanger_SESSION] as List<SanPham>;
                //Session.Remove(CommonConstants.PriceRanger_SESSION);
                if (Session[CommonConstants.IDPRODUCT_SESSION] != null)
                {
                    return View(tmp.Where(x => x.MaLoai == int.Parse(Session[CommonConstants.IDPRODUCT_SESSION].ToString())).ToPagedList(page, pageSize));
                }
                return View(tmp.ToPagedList(page, pageSize));
            }
            else if (Session[CommonConstants.SORT_SESSION] != null)
            {
                var tmp = Session[CommonConstants.SORT_SESSION] as List<SanPham>;
                //Session.Remove(CommonConstants.SORT_SESSION);
                if (Session[CommonConstants.IDPRODUCT_SESSION] != null)
                {
                    return View(tmp.Where(x => x.MaLoai == int.Parse(Session[CommonConstants.IDPRODUCT_SESSION].ToString())).ToPagedList(page, pageSize));
                }
                return View(tmp.ToPagedList(page, pageSize));
            }
            Session.Add(CommonConstants.EndPriceRange_SESSION, 2090000);
            Session.Add(CommonConstants.StartPriceRange_SESSION, 43000);
            if (string.IsNullOrEmpty(id))
            {
                return View(csdl.SanPhams.ToPagedList(page, pageSize));
            }
            Session.Add(CommonConstants.IDPRODUCT_SESSION, id);
            char[] chararr = id.ToCharArray();
            bool chknumber = true;
            foreach (var item in chararr)
            {
                if (!Char.IsDigit(item))
                {
                    chknumber = false;
                }
            }
            if (chknumber)
            {
                return View(csdl.SanPhams.Where(x => x.MaLoai == int.Parse(id)).ToPagedList(page, pageSize));
            }
            return View(csdl.SanPhams.Where(x => x.TenSP == id).ToPagedList(page, pageSize));
        }

        public JsonResult GetProducts(int start, int end)
        {
            Session.Add(CommonConstants.EndPriceRange_SESSION, end);
            Session.Add(CommonConstants.StartPriceRange_SESSION, start);
            if (start == end)
            {
                var tmp3 = csdl.SanPhams.Where(x => x.GiaBan == start).ToList();
                Session.Add(CommonConstants.PriceRanger_SESSION, tmp3);
            }
            else
            {
                Session.Add(CommonConstants.PriceRanger_SESSION, csdl.SanPhams.Where(x => x.GiaBan <= end && x.GiaBan >= start).ToList());
            }
            return Json(new
            {
                status = true
            });
        }

        public JsonResult ListName(string q)
        {
            var data = csdl.SanPhams.Where(x => x.TenSP.ToLower().Contains(q.ToLower())).Select(x => x.TenSP).ToList();
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SortProduct(string sort)
        {
            if (Session[CommonConstants.PriceRanger_SESSION] != null)
            {
                Session.Remove(CommonConstants.PriceRanger_SESSION);
                Session.Add(CommonConstants.EndPriceRange_SESSION, 2090000);
                Session.Add(CommonConstants.StartPriceRange_SESSION, 43000);
            }
            if (sort.Equals("HighToLow"))
            {
                Session.Add(CommonConstants.SORT_SESSION, csdl.SanPhams.OrderByDescending(x => x.GiaBan).ToList());
            }
            else if (sort.Equals("LowToHigh"))
            {
                Session.Add(CommonConstants.SORT_SESSION, csdl.SanPhams.OrderBy(x => x.GiaBan).ToList());
            }
            else
            {
                Session.Add(CommonConstants.SORT_SESSION, csdl.SanPhams.OrderBy(x => x.CreatedDate).ToList());
            }
            return RedirectToAction("ListProduct");
        }

        private QLDoDungTreEmDataContext csdl = new QLDoDungTreEmDataContext();

        public ActionResult ViewDetail1Product(string id)
        {
            return View(csdl.SanPhams.FirstOrDefault(x => x.MaSP == id));
        }
    }
}