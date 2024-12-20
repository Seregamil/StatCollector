using System;

namespace ServiceMan.BaseLibrary.Exceptions;

public class NotSuccessRequest : Exception
{
    public NotSuccessRequest()
        : base()
    {
    }

    public NotSuccessRequest(string message) : base(message)
    {
    }
}