using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InfinityTask.Core.EntityModel;
using InfinityTask.Core.IRepositories;
using InfinityTask.Persistance.Initializer;
using InfinityTask.ViewModel;

namespace InfinityTask.Persistance.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {

        public BlogRepository(MyContext context)
            : base(context)
        {
        }

        public void AddBlogs()
        {
            List<Blog> blogs = MyDbInitializer.AddBlogs(context);
            context.AddRange(blogs);
            context.SaveChanges();
        }

        public void Save(Blog newBlog)
        {

            context.Add(newBlog);
            context.SaveChanges();
        }


    }

}
