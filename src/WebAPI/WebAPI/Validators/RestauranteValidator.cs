using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Validators
{
    public class RestauranteValidator : AbstractValidator<restaurante>
    {
        public RestauranteValidator()
        {
            RuleFor(c => c.nome).NotEmpty().NotNull().WithMessage("Preencha o campo 'Nome'")
                    .MinimumLength(5).WithMessage("O campo 'Nome' deve possuir no mínimo 5 caracteres")
                    .MaximumLength(1000).WithMessage("O campo 'Nome' deve possuir no máximo 1000 caracteres");
        }
    }
}
