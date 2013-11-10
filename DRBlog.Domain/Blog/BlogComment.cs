using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRBlog.Domain.Blog
{
    public class BlogComment : BaseEntity
    {
        public int CustomerId { get; set; }

        public string CommentText { get; set; }

        public int BlogPostId { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        ///public virtual Customer Customer { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
