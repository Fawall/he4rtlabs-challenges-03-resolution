using Heart.API.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Heart.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Ocorreu algum erro interno na aplicação",
                Sucess = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Message = message,
                Sucess = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel 
            {
                Message = message,
                Sucess = false,
                Data = errors
            };
        }

        public static ResultViewModel UnathorizedErrorMessage()
        {
            return new ResultViewModel 
            {
                Message = "Os dados informados estão incorretos",
                Sucess = false,
                Data = null
            };
        }

    }
}