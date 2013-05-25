using System;

namespace Goals.Metadata {
    public abstract class FormInputAttribute : Attribute {
        public abstract string TemplateHint { get; }
    }
}