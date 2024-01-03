using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekton.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() {

            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{Name} no puede estar en blanco")
               .NotNull()
               .MaximumLength(100).WithMessage("{Nombre} no puede exceder los 100 caracteres");

            RuleFor(p => p.Description)
                .MaximumLength(200)
                 .NotEmpty().WithMessage("La {Description} no puede estar en blanco");
        }
    }
}
