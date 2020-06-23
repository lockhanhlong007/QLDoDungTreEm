using System.Collections.Generic;
using System.Linq;

namespace ModelsDungChung.DataAccessObject
{
    public class DataAccessObject
    {
        private QLDoDungTreEmDataContext csdl;

        public DataAccessObject()
        {
            csdl = new QLDoDungTreEmDataContext();
        }

        public Manager GetByID(string UserName)
        {
            return csdl.Managers.SingleOrDefault(x => x.UserName == UserName);
        }

        public KhachHang GetByID_KH(string UserName)
        {
            return csdl.KhachHangs.SingleOrDefault(x => x.TaiKhoan == UserName);
        }

        public int Login(string username, string password)
        {
            var result = csdl.Managers.SingleOrDefault(x => x.UserName == username);
            if (result == null)
            {
                return -1;
            }
            else if (result.Password == password)
            {
                return 1;
            }
            else if (result.Password != password)
            {
                return -2;
            }
            return 0;
        }

        public List<string> GetListPermission(string userName)
        {
            var user = csdl.Managers.Single(x => x.UserName == userName);
            var data = (from a in csdl.Permissions
                        join b in csdl.ManagerGroups on a.ID_Group equals b.ID_Group
                        join c in csdl.Roles on a.ID_Role equals c.ID_Role
                        where b.ID_Group == user.GroupID
                        select new
                        {
                            RoleID = a.ID_Role,
                            UserGroupID = a.ID_Group
                        }).AsEnumerable().Select(x => new Permission()
                        {
                            ID_Role = x.RoleID,
                            ID_Group = x.UserGroupID
                        });
            return data.Select(x => x.ID_Role).ToList();
        }

        public int LoginKH(string username, string password)
        {
            var result = csdl.KhachHangs.SingleOrDefault(x => x.TaiKhoan == username);
            if (result == null)
            {
                return 0;
            }
            else if (result.MatKhau != password)
            {
                return -2;
            }
            else if (!result.Status)
            {
                return -1;
            }
            return 1;
        }
    }
}