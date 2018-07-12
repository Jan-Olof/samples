using LaYumba.Functional;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Samples.Functional.Helpers
{
    public static class ConnectionHelper
    {
        public static R Connect<R>(string connString, Func<IDbConnection, R> func)
            => F.Using(new SqlConnection(connString)
                , conn => { conn.Open(); return func(conn); });

        public static R Transact<R>
            (SqlConnection conn, Func<SqlTransaction, R> f)
        {
            R r = default(R);
            using (var tran = conn.BeginTransaction())
            {
                r = f(tran);
                tran.Commit();
            }
            return r;
        }
    }
}