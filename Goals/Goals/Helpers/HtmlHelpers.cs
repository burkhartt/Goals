using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Goals.Helpers {
    public static class HtmlHelpers {
        public static MvcHtmlString AddNavButton(this HtmlHelper htmlHelper, string title, string action, string controller) {
            var currentController = (string)htmlHelper.ViewContext.RouteData.Values["Controller"];
            var currentAction = (string)htmlHelper.ViewContext.RouteData.Values["Action"];
            var isActive = currentController.Equals(controller, StringComparison.OrdinalIgnoreCase) && currentAction.Equals(action, StringComparison.OrdinalIgnoreCase);
            return new MvcHtmlString("<li class=\"" + (isActive ? "active" : "") + "\">" + htmlHelper.ActionLink(title, action, controller) + "</li>");
        }
    }
}