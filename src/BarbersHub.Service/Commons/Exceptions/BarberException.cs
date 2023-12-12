namespace BarbersHub.Service.Commons.Exceptions;

public class BarberException : Exception
{
    public int statusCode;

    public BarberException(int Code, string Message) : base(Message)
    {
        statusCode = Code;
    }
}
