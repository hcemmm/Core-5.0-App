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
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Resim boş bırakılamaz");

        }
    }
}
