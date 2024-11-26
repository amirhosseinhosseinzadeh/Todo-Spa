﻿namespace Todo.Api.Infrastuctures.Excepetions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException()
    { }

    public EntityNotFoundException(string message, Exception? innerException = null)
        : base(message, innerException)
    { }


    public static void ThrowIfNull<TSource>(TSource source)
    {
        if (source is not { })
        {
            throw new EntityNotFoundException("Entity not found!");
        }
    }

    public static void ThrowIfNull<TSource>(TSource source, string message)
    {
        if (source is not { })
        {
            throw new EntityNotFoundException("Entity not found!");
        }
    }
}