using Backend.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Validators
{
    public class CreateConversationValidator: AbstractValidator<CreateConversationDTO>
    {
        public CreateConversationValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().NotNull().Length(min: 2, max: 50);
        }
    }
}
