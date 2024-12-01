using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Book.DataAcess.Data;
using Book.DataAcess.Repository.IRepository;
using Book.Models;

namespace Book.DataAcess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
         _db = db;

        }
       
        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
