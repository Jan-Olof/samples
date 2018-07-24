using LaYumba.Functional;
using System;
using static LaYumba.Functional.F;

namespace Samples.Functional.Helpers
{
    public static class PersistenceHelper
    {
        /// <summary>
        /// Persist an object to the data store.
        /// </summary>
        public static Exceptional<ValueTuple> Save<T>(this T o, Func<T, int> insert)
        {
            try
            {
                insert(o);
            }
            catch (Exception ex)
            {
                return ex;
            }

            return Unit();
        }
    }
}