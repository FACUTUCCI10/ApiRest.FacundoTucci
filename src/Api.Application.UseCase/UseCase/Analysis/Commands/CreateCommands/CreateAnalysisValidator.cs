using FluentValidation;

namespace Api.Application.UseCase.UseCase.Analysis.Commands.CreateCommands
{
    public class CreateAnalysisValidator :AbstractValidator<CreateAnalysisCommand>
    {
        public CreateAnalysisValidator() 
        {
            RuleFor(x => x.Name).NotNull().WithMessage("El campo 'Nombre' no puede ser nulo/The field 'Name' cannot be null")
                .NotEmpty().WithMessage("El campo 'Nombre' no puede estar vacio/The field 'Name' cannot be empty");
        }
    }
}
