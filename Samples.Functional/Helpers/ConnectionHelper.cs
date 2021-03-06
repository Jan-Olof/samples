﻿// ReSharper disable InconsistentNaming

using LaYumba.Functional;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Samples.Functional.Helpers
{
    public static class ConnectionHelper
    {
        public static R Connect<R>(ConnectionString connString, Func<IDbConnection, R> func)
            => F.Using(new SqlConnection(connString)
                , conn => { conn.Open(); return func(conn); });

        public static R Transact<R>
            (SqlConnection conn, Func<SqlTransaction, R> f)
        {
            R r;
            using (var tran = conn.BeginTransaction())
            {
                r = f(tran);
                tran.Commit();
            }
            return r;
        }
    }
}