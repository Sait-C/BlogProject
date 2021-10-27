using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog Title cannot be blank!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog Content cannot be blank!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Image cannot be blank!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Image cannot be blank!");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("The blog title must be less than 150 characters!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("The blog title must be more than 5 characters!");
            RuleFor(x => x.Content).MinimumLength(50).WithMessage("The blog content must be more than 5 characters!");
        }
    }
}
