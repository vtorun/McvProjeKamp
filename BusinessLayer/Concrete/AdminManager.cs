using BusinessLayer.Abstract;
using BusinessLayer.Hashing;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        //Cryptology cryptology;
        public void AdminAdd(Admin admin)
        {
            admin.AdminUserName = Cryptology.Encryption(admin.AdminUserName);
            admin.AdminPassword = Cryptology.Encryption(admin.AdminPassword);
            _adminDal.Add(admin);
        }

        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin admin)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAll()
        {
            return _adminDal.List();
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public Admin GetByAdmin(string userName, string password)
        {

            return _adminDal.Get(x => userName == Cryptology.Decryption(x.AdminUserName) && password == Cryptology.Decryption(x.AdminPassword));
        }
    }
}
