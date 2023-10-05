using Backend.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Validators
{
    public class CreateMessageValidator: AbstractValidator<CreateMessageDTO>
    {
        public CreateMessageValidator()
        {
            RuleFor(dto => dto.Text).NotNull().NotEmpty();
        }
    }
}
