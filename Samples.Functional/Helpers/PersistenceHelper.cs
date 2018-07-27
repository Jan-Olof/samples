using LaYumba.Functional;
using System;
using static LaYumba.Functional.F;

namespace Samples.Functional.Helpers
{
    public static class PersistenceHelper
    {
        public static Exceptional<TR> Query<T, TR>(this T o, Func<T, TR> query)
        {
            TR result;

            try
            {
                result = query(o);
            }
            catch (Exception ex)
            {
                return ex;
            }

            return result;
        }

        public static Exceptional<TR> Query<TR>(Func<object, TR> query)
        {
            TR result;

            try
            {
                result = query(new object());
            }
            catch (Exception ex)
            {
                return ex;
            }

            return result;
        }

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