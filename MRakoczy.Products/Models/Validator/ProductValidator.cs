using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MRakoczy.Application.Models.Dto;

namespace MRakoczy.Application.Models.Validator
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(100)
                .WithMessage("Max 100 chars");

            RuleFor(p => p.Price)
                .LessThan(0)
                .WithMessage("Price must be less than 0");

        }
    }
}
