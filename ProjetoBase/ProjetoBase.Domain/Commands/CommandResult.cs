using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace ProjetoBase.Domain.Commands
{
    public class CommandResult
    {
        private IDictionary<string, List<string>> Validations { get; set; }
        private List<string> Messages { get; } = new List<string>();
        private List<string> Errors { get; } = new List<string>();

        public object Model { get; }

        public bool IsValid => (Validations == null || !Validations.Any()) && (Errors == null || Errors.Count == 0);

        public CommandResult() { }

        public CommandResult(object model)
        {
            Model = model;
        }

        public void AddValidations(IEnumerable<ValidationResult> validations)
        {
            Validations = validations
                .Where(v => !v.IsValid)
                .SelectMany(v => v.Errors)
                .GroupBy(v => v.PropertyName)
                .ToDictionary(grp => grp.Key, grp => grp.Select(v => v.ErrorMessage).ToList());
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public IReadOnlyDictionary<string, IReadOnlyList<string>> ListValidations()
        {
            return Validations?.ToDictionary(v => v.Key, v => (IReadOnlyList<string>)v.Value);
        }

        public IReadOnlyList<string> ListMessages()
        {
            return Messages;
        }

        public IReadOnlyList<string> ListErrors()
        {
            return Errors;
        }

        public TModel GetModel<TModel>() where TModel : class
        {
            return Model as TModel;
        }
    }
}
