using System;

namespace QLDoDungTreEm.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string GroupID { set; get; }
    }
}