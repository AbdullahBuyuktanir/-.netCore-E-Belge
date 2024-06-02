using E_Belge.Model.DataTransferObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Model.Validators.Customers
{
  public class CreateUpdateCustomerValidator : AbstractValidator<CreateUpdateCariDto>
  {
    public CreateUpdateCustomerValidator()
    {
      RuleFor(x => x.Adi).NotEmpty().NotNull().WithMessage("'Adi' bir değer içermelidir.")
        .MaximumLength(100).MinimumLength(3).WithMessage("'Ad' 3 ile 100 karakter arasında olmalıdır.");

      RuleFor(x => x.Kodu).MaximumLength(10).WithMessage("'Kodu' 10 karakterden fazla olamaz.");

      RuleFor(x => x.VergiDairesi).NotEmpty().WithMessage("'Vergi Dairesi' bir değer içermelidir.");
      RuleFor(x => x.VknTckn).NotNull().WithMessage("'Vergi Dairesi' bir değer içermelidir.")
        .MinimumLength(10). MaximumLength(11).WithMessage("VergiNo - TcNo en az 10 en çok 11 karakter olabilir.")
        .Matches("[0-9]*").WithMessage("Vkn - TcNo harf içeremez.");

      RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir email olmalıdır.");
    }
  }
}
