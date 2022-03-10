using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("En fazla 50 karakter giriniz");
        }
    }
}
