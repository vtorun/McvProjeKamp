using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> genericRepository = new GenericRepository<Category>();
        public List<Category> getAll()
        {
            return genericRepository.List();
        }
        public void CategoryAdd(Category category)
        {
            if (category.CategoryName == "" || category.CategoryName.Length <= 3 ||
                    category.CategoryDescription == "" || category.CategoryName.Length >= 50)
            {
            }
            else
            {
                genericRepository.Add(category);
            }
        }
    }
}
