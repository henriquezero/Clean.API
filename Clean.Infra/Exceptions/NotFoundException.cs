using System.Net;

namespace Clean.Infra.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string message)
        : base(message, null, HttpStatusCode.NotFound)
        {
        }
    }
}
