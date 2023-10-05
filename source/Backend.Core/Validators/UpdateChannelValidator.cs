using Backend.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Validators
{
    public class UpdateChannelValidator: AbstractValidator<UpdateChannelDTO>
    {
        public UpdateChannelValidator() 
        { 
            RuleFor(dto => dto.Description).NotNull();
        }
    }
}
