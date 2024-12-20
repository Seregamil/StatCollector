using System;

namespace ServiceMan.BaseLibrary.Exceptions;

public class NotFoundedException : Exception
{
    public NotFoundedException()
    {
    }

    public NotFoundedException(string message) : base(message)
    {
    }
}