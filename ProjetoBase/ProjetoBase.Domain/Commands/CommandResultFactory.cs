using ProjetoBase.Domain.Messages;

namespace ProjetoBase.Domain.Commands
{
    public static class CommandResultFactory
    {
        public static CommandResult InsertSucessResult<T>(object model)
        {
            var result = new CommandResult(model);
            result.AddMessage(BusinessMessages.InsertSucess<T>());
            return result;
        }

        public static CommandResult UpdateSucessResult<T>(object model)
        {
            var result = new CommandResult(model);
            result.AddMessage(BusinessMessages.UpdateSucess<T>());
            return result;
        }

        public static CommandResult DeleteSucessResult<T>(object model = null)
        {
            var result = new CommandResult(model);
            result.AddMessage(BusinessMessages.DeleteSucess<T>());
            return result;
        }

        public static CommandResult DuplicatedResult<T>()
        {
            var result = new CommandResult();
            result.AddError(BusinessMessages.DuplicatedError<T>());
            return result;
        }

        public static CommandResult NotFoundResult<T>()
        {
            var result = new CommandResult();
            result.AddError(BusinessMessages.NotFoundError<T>());
            return result;
        }

        public static CommandResult SucessResult()
        {
            return SucessResult(null);
        }

        public static CommandResult SucessResult(object model)
        {
            var result = new CommandResult(model);
            result.AddMessage(BusinessMessages.GenericSucess());
            return result;
        }

        public static CommandResult None()
        {
            return new CommandResult();
        }

        public static CommandResult Message(string message)
        {
            var result = new CommandResult();
            result.AddMessage(message);
            return result;
        }

        public static CommandResult Error(params string[] errors)
        {
            var result = new CommandResult();
            foreach (var error in errors) result.AddError(error);
            return result;
        }
    }
}
