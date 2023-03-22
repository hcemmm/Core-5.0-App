using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı maksimum 50 karakter olabilir");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı minimum 3 karakter olmalıdır");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x => x.CategoryDescription).MinimumLength(50).WithMessage("Kategori açıklaması minimum 50 karakter olabilir");


        }
    }
}
