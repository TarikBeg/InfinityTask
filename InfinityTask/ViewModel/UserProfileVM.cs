using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinityTask.ViewModel
{
    public class UserProfileVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Search { get; set; }
        public DateTime LowerDate { get; set; }
        public DateTime UpperDate { get; set; }
    }
}
