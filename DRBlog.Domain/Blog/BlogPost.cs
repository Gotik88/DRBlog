using System;
using System.Collections.Generic;
using DRBlog.Core.Domain;

namespace DRBlog.Domain.Blog
{
    public class BlogPost : BaseEntity
    {
        private ICollection<BlogComment> _blogComments;

        public int LanguageId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool AllowComments { get; set; }

        public int CommentCount { get; set; }

        public string Tags { get; set; }

        public DateTime? StartDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public virtual bool LimitedToStores { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public virtual ICollection<BlogComment> BlogComments
        {
            get { return _blogComments ?? (_blogComments = new List<BlogComment>()); }
            protected set { _blogComments = value; }
        }

        // public virtual Language Language { get; set; }
    }
}
