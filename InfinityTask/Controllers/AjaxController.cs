using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InfinityTask.Core.EntityModel;
using InfinityTask.Helper;
using InfinityTask.Persistance;
using InfinityTask.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using ReflectionIT.Mvc.Paging;

namespace InfinityTask.Controllers
{
    public class AjaxController : Controller
    {
        private static IMapper _mapper;
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new MyContext());

        public AjaxController(IMapper mapper,MyContext context)
        {
            _mapper = mapper;
        }

        public IActionResult Index(string Id,int ?page,string search)
        {
            IQueryable blogs;
            blogs = _unitOfWork.Blog.Get(m => m.Id == Id);

            if (!string.IsNullOrEmpty(search) )
                blogs = _unitOfWork.Blog.Get(o => o.Id == Id && o.Title == search);
            
            var mappedBlogs = _mapper.Map<List<BlogListVM>>(blogs);
            var paged = new PagedData()
            {
                List = PagingList.Create(mappedBlogs, 3, page ?? 1),
                NumberOfPages = Convert.ToInt32(Math.Ceiling((double) mappedBlogs.Count()) / 3),
                CurrentPage = 1,
                UserId = Id
            };
               
            if (mappedBlogs==null)
           {
               TempData["Error-Messages"] = "There are no created blogs";
               return PartialView();
           }
          
               return PartialView(paged);
        }

        public IActionResult CreateBlog(string Id,int BlogId)
        {
            Blog blog;
            NewBlog model = new NewBlog();
            blog = _unitOfWork.Blog.GetByIDInt(BlogId);
            if (blog!=null)
            {
                model = _mapper.Map<NewBlog>(blog);
            }
           
            model.Id = Id;
            return PartialView(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(NewBlog model)
        {
            if (!ModelState.IsValid)
            {
                 model = new NewBlog();
                return PartialView("CreateBlog",model);
            }

            if (model.PublishDate<DateTime.Now)
            {
                model = new NewBlog();
                return PartialView("CreateBlog", model);
            }
            Blog newBlog=new Blog();
            newBlog=_mapper.Map<Blog>(model);
            
            _unitOfWork.Blog.Save(newBlog);
            return Redirect(" / AjaxController / Index ? userId = " + model.Id);
        }
    }
}