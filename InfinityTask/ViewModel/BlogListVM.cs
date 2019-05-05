using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinityTask.ViewModel
{
    public class BlogListVM
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
        public int BlogId { get; set; }
    }
}
