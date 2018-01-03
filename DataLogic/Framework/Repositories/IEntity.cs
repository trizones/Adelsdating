﻿namespace AdelsDating.Framework.Repositories
{   //Skapad för att ge varje subklass ett ID
    public interface IEntity : IEntity<int> { }
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}