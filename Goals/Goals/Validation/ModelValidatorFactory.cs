using System;
using System.Web.Mvc;
using FluentValidation;

namespace Goals.Validation {
    public class ModelValidatorFactory : IValidatorFactory
    {
        public IValidator GetValidator(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return DependencyResolver.Current.GetService(typeof(IValidator<>).MakeGenericType(type)) as IValidator;
        }

        public IValidator<T> GetValidator<T>()
        {
            return DependencyResolver.Current.GetService<IValidator<T>>();
        }
    }
}