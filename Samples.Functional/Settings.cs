using System.Text.RegularExpressions;

namespace Samples.Functional
{
    public static class Settings
    {
        public static Regex BicCodeRegex()
            => new Regex("^[A-Z]{6}[A-Z1-9]{5}$");
    }
}