using Backend.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Validators
{
    public class UpdateMessageValidator: AbstractValidator<UpdateMessageDTO>
    {
        public UpdateMessageValidator() 
        { 
            RuleFor(dto => dto.Text).NotEmpty().NotNull();
        }
    }
}
