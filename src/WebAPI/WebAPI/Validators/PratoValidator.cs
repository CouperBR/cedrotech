using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Validators
{
    public class PratoValidator : AbstractValidator<prato>
    {
        public PratoValidator()
        {
            RuleFor(c => c.nome).NotEmpty().WithMessage("Preencha o campo 'Nome'")
                    .MinimumLength(5).WithMessage("O campo 'Nome' deve possuir no mínimo 5 caracteres")
                    .MaximumLength(1000).WithMessage("O campo 'Nome' deve possuir no máximo 1000 caracteres");

            RuleFor(c => c.preco).NotEmpty().WithMessage("Preencha o campo 'Preço'")
                    .ExclusiveBetween(1, 500).WithMessage("O campo 'Preço' deve estar entre 1 e 500.");

            RuleFor(c => c.restauranteId).NotEmpty().WithMessage("Preencha o campo 'Restaurante'.");
        }
    }
}
