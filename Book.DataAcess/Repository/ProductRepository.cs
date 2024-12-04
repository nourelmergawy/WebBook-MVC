﻿using System;
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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) 
        {
         _db = db;

        }
       
        public void Update(Product product)
        {
            _db.Products.Update(product);
        }
    }
}
