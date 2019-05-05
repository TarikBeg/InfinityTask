﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityTask.Core.IRepositories;
using InfinityTask.Core.EntityModel;

namespace InfinityTask.Core.IRepositories
{
    public interface IBlogRepository:IGenericRepository<Blog>
    {
       void AddBlogs();
        void Save(Blog Model);
    }
}
