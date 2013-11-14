
using DRBlog.Core.Domain;

namespace DRBlog.Domain.Blog
{
    public class BlogPostTag : BaseEntity
    {
        public string Name { get; set; }

        public int BlogPostCount { get; set; }
    }
}
