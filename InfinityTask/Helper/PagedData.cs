using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityTask.ViewModel;
using ReflectionIT.Mvc.Paging;

namespace InfinityTask.Helper
{
    public class PagedData
    {
        public PagingList<BlogListVM> List { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
        public string UserId { get; set; }
        
    }
}
