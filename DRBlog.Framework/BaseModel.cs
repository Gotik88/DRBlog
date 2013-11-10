using System.Collections.Generic;
using System.Web.Mvc;

namespace DRBlog.Framework
{
    public class BaseModel
    {
        public BaseModel()
        {
            this.CustomProperties = new Dictionary<string, object>();
        }
        public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
        }

        /// <summary>
        /// Use this property to store any custom value for your models. 
        /// </summary>
        public Dictionary<string, object> CustomProperties { get; set; }
    }

    public class BaseEntityModel : BaseModel
    {
        public virtual int Id { get; set; }
    }
}
