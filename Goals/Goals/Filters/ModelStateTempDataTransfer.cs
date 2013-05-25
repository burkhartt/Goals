using System.Web.Mvc;

namespace Goals.Filters {
    public abstract class ModelStateTempDataTransfer : ActionFilterAttribute {
        protected static readonly string Key = typeof (ModelStateTempDataTransfer).FullName;
    }
}