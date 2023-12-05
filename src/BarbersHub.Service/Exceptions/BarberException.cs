namespace BarbersHub.Service.Exceptions;

public class BarberException : Exception
{
    public int statusCode;

    public BarberException(int Code, string Message) : base(Message)
    {
        this.statusCode = Code;
    }
}
