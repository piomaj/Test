﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.DAL.Interfaces
{
    public interface IProductCategories
    {
        ProductCategory GetById(Guid guid);
    }
}
