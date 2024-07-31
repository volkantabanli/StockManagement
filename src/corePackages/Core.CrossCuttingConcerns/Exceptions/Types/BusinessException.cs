using System.Runtime.Serialization;

namespace Core.CrossCuttingConcerns.Exceptions.Types;

public class BusinessException : Exception
{
    public string responseMessage { get; set; }
    public BusinessException() { }

    protected BusinessException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    public BusinessException(string? message)
        : base(message)
    {
        responseMessage = message;
    }

    public BusinessException(string? message, Exception? innerException)
        : base(message, innerException)
    {
        responseMessage = message ?? string.Empty;
    }
}
