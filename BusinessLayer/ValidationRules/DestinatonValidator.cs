using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DestinatonValidator : AbstractValidator<Destination>
    {
        public DestinatonValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage(" Boş Bırakılamaz")
                .MinimumLength(5).WithMessage(" En Az 5 Karakter Olabilir");

            RuleFor(x => x.DayNight).NotEmpty().WithMessage(" Boş Bırakılamaz")
                .MinimumLength(5).WithMessage(" En Az 5 Karakter Olabilir");

            RuleFor(x => x.Capacity).NotEmpty().WithMessage(" Boş bırakılamaz.")
               .GreaterThan(0).WithMessage(" 0 Dan Büyük Olmalıdır");

            RuleFor(x => x.Image).NotEmpty().WithMessage(" Boş Bırakılamaz");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş bırakılamaz.")
                .GreaterThan(0).WithMessage(" 0 Dan Büyük Olmalıdır");

            RuleFor(x => x.Description).NotEmpty().WithMessage(" Boş Bırakılamaz")
                .MinimumLength(25).WithMessage(" En Az 25 Karakter Olabilir")
                .MaximumLength(100).WithMessage(" En Fazla 100 Karakter Olabilir");


        }
    }
}
