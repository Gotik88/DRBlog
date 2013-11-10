using System.Web.Mvc;
using DRBlog.Framework;

namespace DRBlog.Web.Models
{
    public class AddBlogCommentModel : BaseEntityModel
    {
        [AllowHtml]
        public string CommentText { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}