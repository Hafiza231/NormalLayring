using Layring.DL;
using Layring.EL.Model;
using Layring.EL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layering.BL
{
    public class UserBL
    {
        public List<UserViewModel> GetUserList()
        {
            UserDL udl = new UserDL();
           return udl.userList1();
        }
        public bool AddUserBL(UserViewModel vmodel)
        {
            UserDL udl = new UserDL();
            var userreturn = udl.AddUser(vmodel);
        
           return userreturn;
        
        }
    }
}
