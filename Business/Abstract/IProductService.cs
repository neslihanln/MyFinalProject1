﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId (int id); // category idye göre ürünleri getir
        List<Product> GetAllByUnitPrice (decimal min , decimal max);
    }
}
