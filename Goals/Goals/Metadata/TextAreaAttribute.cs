using Goals.Models;

namespace Goals.Metadata {
    public class TextAreaAttribute : FormInputAttribute {
        public override string TemplateHint {
            get { return "Textarea"; }
        }
    }
}