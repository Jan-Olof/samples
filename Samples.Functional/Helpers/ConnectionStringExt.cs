using Dapper;
using System;
using System.Collections.Generic;

using static Samples.Functional.Helpers.ConnectionHelper;

namespace Samples.Functional.Helpers
{
    public static class ConnectionStringExt
    {
        public static Func<SqlTemplate, T, int> Execute<T>(this ConnectionString conStr) =>
            (sql, param) => Connect(conStr, conn => conn.Execute(sql, param));

        public static Func<SqlTemplate, object, IEnumerable<T>> Query<T>(this ConnectionString conStr) =>
            (sql, param) => Connect(conStr, conn => conn.Query<T>(sql, param));
    }
}