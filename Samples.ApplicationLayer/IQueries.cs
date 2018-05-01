using System;
using System.Collections.Generic;

namespace Samples.ApplicationLayer
{
    public interface IQueries<out T>
    {
        /// <summary>
        /// Get one object from the data store.
        /// </summary>
        T Get(Guid id);

        /// <summary>
        /// Get all objects from the data store.
        /// </summary>
        IEnumerable<T> GetAll();
    }
}