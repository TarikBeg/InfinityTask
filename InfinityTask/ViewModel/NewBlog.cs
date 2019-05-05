using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InfinityTask.Helper;

namespace InfinityTask.ViewModel
{
    public class NewBlog
    {
        public string Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Title { get; set; }
        [Required]
        [StringLength(350)]
        public string Summary { get; set; }
        [Required]
        [StringLength(3500)]
        public string Content { get; set; }
        [Required]
        [DateValidation]
        public DateTime PublishDate { get; set; }
    }
}
