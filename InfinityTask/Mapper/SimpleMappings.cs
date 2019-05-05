using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InfinityTask.Core.EntityModel;
using InfinityTask.ViewModel;

namespace InfinityTask.Mapper
{
    public class SimpleMappings:Profile
    {
        public SimpleMappings()
        {
            CreateMap<AppUser,UserListVM>();
            CreateMap<AppUser, UserProfileVM>();
            CreateMap<Blog, BlogListVM>();
            CreateMap<Blog, NewBlog>().ReverseMap();
            CreateMap<Blog, NewBlog>();
        }
    }
}
