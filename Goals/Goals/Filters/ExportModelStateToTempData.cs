using System.Web.Mvc;

namespace Goals.Filters {
    public class ExportModelStateToTempData : ModelStateTempDataTransfer {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (!filterContext.Controller.ViewData.ModelState.IsValid &&
                filterContext.HttpContext.Request.RequestType == "POST") {
                filterContext.Controller.TempData[Key] = filterContext.Controller.ViewData.ModelState;
                filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.UrlReferrer.AbsoluteUri);
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}