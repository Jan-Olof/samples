namespace Samples.Functional.Helpers
{
    /// <summary>
    /// A connection string to a database.
    /// </summary>
    public class ConnectionString
    {
        private ConnectionString(string value) => Value = value;

        private string Value { get; }

        public static implicit operator ConnectionString(string s) => new ConnectionString(s);

        public static implicit operator string(ConnectionString c) => c.Value;

        /// <inheritdoc />
        public override string ToString() => Value;
    }
}