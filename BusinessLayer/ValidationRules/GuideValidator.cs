using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(" - Boş Bırakılamaz")
                .MaximumLength(100).WithMessage(" - 100 Karakteri Geçemez")
                .MinimumLength(10).WithMessage(" - En Az 10 Karakter Olmadılıdır");

            RuleFor(x => x.Description).NotEmpty().WithMessage(" - Boş Bırakılamaz")
                .MaximumLength(300).WithMessage(" - 300 Karakteri Geçemez")
                .MinimumLength(30).WithMessage(" - En Az 30 Karakter Olmalıdır");

            RuleFor(x => x.Image).NotEmpty().WithMessage(" - Boş Bırakılamaz");
        }
    }
}
