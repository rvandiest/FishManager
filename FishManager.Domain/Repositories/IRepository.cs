using System;
using System.Collections.Generic;

namespace FishManager.Domain.Repositories
{
    public interface IRepository<T>
    {
        U FindOne<U>(Func<T, bool> predicate);
        U FindOne<U>(Func<T, bool> predicate, Func<T, U> projector);
        U FindOneOrCreate<U>(Func<T, bool> predicate, T value, Func<T, U> projector);
        U FindOneOrCreate<U>(Func<T, bool> predicate, T value);
        IEnumerable<U> FindAll<U>(Func<T, bool> predicate);
        IEnumerable<U> FindAll<U>(Func<T, bool> predicate, Func<T, U> projector);
        U InsertOne<U>(T value, Func<T, U> projector);
        U InsertOne<U>(T value);
        IEnumerable<U> InsertAll<U>(IEnumerable<T> value, Func<T, U> projector);
        IEnumerable<U> InsertAll<U>(IEnumerable<T> value);
        U UpdateOne<U>(T value, Func<T, U> projector);
        U UpdateOne<U>(T value);
        IEnumerable<U> UpdateAll<U>(IEnumerable<T> value, Func<T, U> projector);
        IEnumerable<U> UpdateAll<U>(IEnumerable<T> value);
        void DeleteOne(Func<T, bool> predicate);
        void DeleteAll(Func<T, bool> predicate);
    }
}