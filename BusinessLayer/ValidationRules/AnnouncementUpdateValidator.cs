using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Boş Bırakılamaz")
               .MinimumLength(3).WithMessage("En Az 3 Karakter Girin")
               .MaximumLength(50).WithMessage("En Fazla 50 Karakter Girin");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Boş Bırakılamaz")
                .MinimumLength(3).WithMessage("En Az 3 Karakter Girin")
                .MaximumLength(500).WithMessage("En Fazla 500 Karakter Girin");
        }
    }
}
