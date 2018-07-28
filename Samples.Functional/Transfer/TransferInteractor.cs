using LaYumba.Functional;
using Samples.Functional.Helpers;
using System;
using System.Collections.Generic;
using static Samples.Functional.Helpers.PersistenceHelper;
using static Samples.Functional.Sql;
using Unit = System.ValueTuple;

namespace Samples.Functional.Transfer
{
    public static class TransferInteractor // TODO: Tests.
    {
        public static Validation<Exceptional<Unit>> Create(this BookTransferDto transfer, Func<DateTime> now, Func<SqlTemplate, BookTransferDao, int> commands)
            => transfer
                .CreateBookTransfer(now)
                .Map(t => t
                    .CreateBookTransferDao()
                    .Save(commands.Apply(GetSqlTemplate(SqlEnum.InsertIntoBookTransfers))));

        public static Exceptional<IEnumerable<BookTransferDto>> GetAll(Func<SqlTemplate, object, IEnumerable<BookTransferDao>> queries)
            => Query(queries.Apply(GetSqlTemplate(SqlEnum.SelectBookTransfers)))
                .Map(daos => daos.Map(dao => dao.CreateBookTransferDto()));

        public static Exceptional<IEnumerable<BookTransferDto>> GetFrom<T>(Func<SqlTemplate, object, IEnumerable<BookTransferDao>> queries, SqlEnum query, T t)
            => t.Query(queries.Apply(GetSqlTemplate(query)))
                .Map(daos => daos.Map(dao => dao.CreateBookTransferDto()));
    }
}