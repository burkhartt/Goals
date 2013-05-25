using System;
using System.Linq;
using System.Web.Mvc;
using Goals.Models;

namespace Goals.Metadata {
    public class MetadataProvider : DataAnnotationsModelMetadataProvider {
        protected override ModelMetadata CreateMetadata(System.Collections.Generic.IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            var formInputAttribute = (FormInputAttribute)attributes.FirstOrDefault(x => x is FormInputAttribute);
            if (formInputAttribute != null) {
                metadata.TemplateHint = formInputAttribute.TemplateHint;
            }            
            return metadata;
        }
    }
}