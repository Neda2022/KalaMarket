﻿using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        ResultDto Execute(long? ParentId, string Name);

    }
}
