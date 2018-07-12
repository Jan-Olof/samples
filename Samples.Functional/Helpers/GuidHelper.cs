using LaYumba.Functional;
using System;
using static LaYumba.Functional.F;

namespace Samples.Functional.Helpers
{
    public static class GuidHelper
    {
        public static bool IsGuid(this string value)
            => value.ToGuid().Match(() => false, guid => true);

        public static Option<Guid> ToGuid(this string value)
            => Guid.TryParse(value, out var guidOutput) ? Some(guidOutput) : None;
    }
}