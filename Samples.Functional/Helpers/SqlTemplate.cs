namespace Samples.Functional.Helpers
{
    /// <summary>
    /// A template for SQL strings.
    /// </summary>
    public class SqlTemplate
    {
        private SqlTemplate(string value) => Value = value;

        private string Value { get; }

        public static implicit operator SqlTemplate(string s) => new SqlTemplate(s);

        public static implicit operator string(SqlTemplate c) => c.Value;

        /// <inheritdoc />
        public override string ToString() => Value;
    }
}