using LaYumba.Functional;
using Samples.Functional.Helpers;
using System;
using System.Collections.Generic;
using static Samples.Functional.Sql;
using Unit = System.ValueTuple;

namespace Samples.Functional.Transfer
{
    public static class TransferInteractor
    {
        public static Validation<Exceptional<Unit>> Create(this BookTransferDto transfer, Func<DateTime> now, Func<SqlTemplate, BookTransferDao, int> commands)
        {
            var insert = commands.Apply(Sql.InsertIntoBookTransfers);

            return transfer
                .CreateBookTransfer(now)
                .Map(t => t
                    .CreateBookTransferDao()
                    .Save(insert));
        }

        public static Exceptional<IEnumerable<BookTransferDao>> GetFromId(this int id, Func<SqlTemplate, object, IEnumerable<BookTransferDao>> queries)
        {
            var query = queries.Apply(SelectBookTransferFromId); // TODO: Continue with this

            return new { Id = id }.Query(query);
        }
    }
}