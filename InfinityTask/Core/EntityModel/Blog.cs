using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace InfinityTask.Core.EntityModel
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
       
        public string Title { get; set; }
       
        public string  Summary { get; set; }
      
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

        [ForeignKey(nameof(Id))]
        public AppUser User { get; set; }
        public string Id { get; set; }
    }
}
