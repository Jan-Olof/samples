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
                    .Save(commands.Apply(InsertIntoBookTransfers)));

        public static Exceptional<IEnumerable<BookTransferDao>> GetAll(Func<SqlTemplate, object, IEnumerable<BookTransferDao>> queries)
            => Query(queries.Apply(SelectBookTransfers));

        public static Exceptional<IEnumerable<BookTransferDao>> GetFromId(this int id, Func<SqlTemplate, object, IEnumerable<BookTransferDao>> queries) // TODO: Generalize?
            => new { Id = id }.Query(queries.Apply(SelectBookTransferFromId));
    }
}