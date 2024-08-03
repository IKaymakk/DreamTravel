using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SendMessageValidator : AbstractValidator<SendMessageDto>
    {
        public SendMessageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Adınızı Girin")
                .MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girin")
                .MaximumLength(60).WithMessage("Lütfen En Fazla 60 Karakter Giriniz");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen Mail Adresi Giriniz")
                .EmailAddress().WithMessage("Lütfen Geçerli Bir Email Adresi Giriniz")
                .MinimumLength(6).WithMessage("Lütfen En Az 6 Karakter Girin")
                .MaximumLength(120).WithMessage("Lütfen En Fazla 120 Karakter Giriniz");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen Bir Konu Giriniz")
                .MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girin")
                .MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen Mesajınızı Giriniz")
                .MinimumLength(10).WithMessage("Lütfen En Az 10 Karakter Girin")
                .MaximumLength(500).WithMessage("Lütfen En Fazla 500 Karakter Giriniz");


        }
    }
}
