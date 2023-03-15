using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator :AbstractValidator<Writer>
	{
        public WriterValidator()
        {
            RuleFor(x => x.WriterNameSurname).NotEmpty().WithMessage("Ad Soyad boş bırakılamaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("E-Posta boş bırakılamaz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş bırakılamaz");

        }
    }
}
