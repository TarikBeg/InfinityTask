using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using InfinityTask.Core.EntityModel;
using InfinityTask.Persistance;
using InfinityTask.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using Remotion.Linq.Clauses.ResultOperators;

namespace InfinityTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new MyContext());

        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }
        //[HttpGet]
        public IActionResult Index(string search, int? page)
        {

            IEnumerable<AppUser> users;
            if (!string.IsNullOrEmpty(search))
            
              users = _unitOfWork.User.Get(m=>m.FirstName==search || m.LastName==search|| m.Email==search,q=>q.OrderBy(o=>o.FirstName));
            
            else
            users = _unitOfWork.User.Get(null, q => q.OrderBy(o => o.FirstName));
            IEnumerable<UserListVM> mappedUsers =_mapper.Map<List<UserListVM>>(users);
            IEnumerable<Blog> getAllBlogs =  _unitOfWork.Blog.Get();

            foreach (UserListVM user in mappedUsers)
            {
                user.BlogNumber = getAllBlogs.Count(u => u.Id == user.Id);
            }

            var model = PagingList.Create(mappedUsers, 5,page??1);
            
            return View("Index",model);
        }
        //[HttpPut("{userId}")]
        public IActionResult UserProfile(string userId)
        {
            var user = _unitOfWork.User.GetByID(userId);
            UserProfileVM mappedUser = _mapper.Map<UserProfileVM>(user);

            return View(mappedUser);
        }
    }
}