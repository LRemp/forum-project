using Backend.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Validators
{
    public class CreateChannelValidator: AbstractValidator<ChannelDTO>
    {
        public CreateChannelValidator() 
        {
            RuleFor(dto => dto.Name).NotNull().NotEmpty().Length(min: 2, max: 50);
        }
    }
}
