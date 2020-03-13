using AutoMapper;
using Layring.EL.Model;
using Layring.EL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layring.DL
{
    public class UserDL
    {
        public List<UserViewModel> userList()
        {
            using (UserEntities db = new UserEntities())
            {
                List<UserViewModel> userViewModels = new List<UserViewModel>();
                List<UserDB> UserDBS = new List<UserDB>();
                UserDBS = db.UserDBs.ToList();

                foreach(UserDB userDBs in UserDBS )
                {
                    UserViewModel vmodel = new UserViewModel();
                    vmodel.UserId = userDBs.UserId;
                    vmodel.UserName = userDBs.UserName;
                    vmodel.UserEmail = userDBs.UserEmail;
                    vmodel.UserAddress = userDBs.UserAddress;
                    vmodel.UserMobile = userDBs.UserMobile;
                    userViewModels.Add(vmodel);
                }
                return userViewModels;

            }

        }
        public List<UserViewModel> userList1()
        {
            using (UserEntities db = new UserEntities())
            {
                List<UserViewModel> userViewModels = new List<UserViewModel>();
                List<UserDB> UserDBS = new List<UserDB>();
                UserDBS = db.UserDBs.ToList();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap <UserDB, UserViewModel> ();
                });
                IMapper mapper = config.CreateMapper();
                userViewModels = mapper.Map<List<UserDB>, List<UserViewModel>>(UserDBS);

               
                return userViewModels;
            }

        }
       public bool AddUser(UserViewModel vmodel)
       {
            using (UserEntities db=new UserEntities())
            {
                UserDB user = new UserDB();
                user.UserName = vmodel.UserName;
                user.UserAddress = vmodel.UserAddress;
                user.UserEmail = vmodel.UserEmail;
                user.UserMobile = vmodel.UserMobile;
                db.UserDBs.Add(user);
                db.SaveChanges();
                if (user!=null)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
           
        }

    }
}
