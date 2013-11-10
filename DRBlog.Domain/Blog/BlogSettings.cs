using DRBlog.Core.Configuration;

namespace DRBlog.Domain.Blog
{
    public class BlogSettings : ISettings
    {
        public bool Enabled { get; set; }

        public int PostsPageSize { get; set; }

        public bool AllowNotRegisteredUsersToLeaveComments { get; set; }

        public bool NotifyAboutNewBlogComments { get; set; }

        public int NumberOfTags { get; set; }

        public bool ShowHeaderRssUrl { get; set; }
    }
}
