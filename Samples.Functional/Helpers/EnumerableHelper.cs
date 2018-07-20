using System.Collections.Generic;
using System.Linq;

namespace Samples.Functional.Helpers
{
    public static class EnumerableHelper
    {
        /// <summary>
        /// An AddRange function.
        /// </summary>
        public static IEnumerable<T> AddMany<T>(this IEnumerable<T> e, IEnumerable<T> n)
        {
            var list = e.ToList();
            list.AddRange(n);
            return list;
        }
    }
}