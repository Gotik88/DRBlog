using System.Web;
using System.Web.Mvc;

namespace DRBlog.Framework.Mvc.ModelBinder
{
    public class CustomModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(TestModel))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;
                return new TestModel();
                // call custom model binding behavior
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }

    public class TestModel
    {
    }
}
