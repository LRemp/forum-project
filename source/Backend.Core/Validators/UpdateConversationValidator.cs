using Backend.Core.DTOs;
using FluentValidation;

namespace Backend.Core.Validators
{
    public class UpdateConversation: AbstractValidator<UpdateConversationDTO>
    {
        public UpdateConversation()
        { 
            RuleFor(dto => dto.Description).NotNull();
        }
    }
}
