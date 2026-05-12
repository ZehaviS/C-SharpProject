

using System;

namespace DO;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(string message)
        : base(message)
    {
        //Console.WriteLine( message);
    }
}

public class CustomerApperException : Exception
{
    public CustomerApperException(string message)
        : base(message)
    {
        //Console.WriteLine(message);

    }
}
