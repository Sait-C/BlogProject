using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    //HEY! You are a validator and you should be validate the writer entity
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            //Validation Rules For Writer Entity
            RuleFor(x => x.FullName).NotEmpty().WithMessage(
                "Author name and surname cannot be blank!");

            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage(
                "Email field cannot be blank!");

            RuleFor(x => x.WriterImage).NotEmpty().WithMessage(
                "Image field cannot be blank!");

            RuleFor(x => x.FullName).MinimumLength(2).WithMessage(
                "Full Name must be at least 2 characters");

            RuleFor(x => x.FullName).MaximumLength(50).WithMessage(
                "Full Name can be up to 50 characters");

            RuleFor(x => x.Password).NotEmpty().WithMessage(
                "Password field cannot be blank!");

            RuleFor(x => x.Password).Matches(@"[0-9]+[A-Z]+[a-z]").WithMessage(
                "Password must contain at least one lowercase letter, one uppercase letter, and one number"); ;
        }
    }
}
