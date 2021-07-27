using BusinessLayer.Abstract;
using BusinessLayer.Hashing;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminLoginDal _adminLoginDal;

        public AdminLoginManager(IAdminLoginDal adminLoginDal)
        {
            _adminLoginDal = adminLoginDal;
        }

        public Admin GetByAdmin(string userName, string password)
        {
            userName = Cryptology.Encryption(userName);
            password = Cryptology.Encryption(password);
            return _adminLoginDal.GetAdmin(x => x.AdminUserName == userName && x.AdminPassword == password);
        }
    }
}

