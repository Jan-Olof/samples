﻿using LaYumba.Functional;
using Samples.Functional.Helpers;
using System;
using static Samples.Functional.SqlTemplates;
using Unit = System.ValueTuple;

namespace Samples.Functional.Transfer
{
    public static class TransferInteractor
    {
        public static Validation<Exceptional<Unit>> Create(this BookTransferDto transfer, Func<DateTime> now, Func<SqlTemplate, BookTransferDao, int> commands)
        {
            var insert = commands.Apply(InsertIntoBookTransfers);

            return transfer
                .CreateBookTransfer(now)
                .Map(t => t
                    .CreateBookTransferDao()
                    .Save(insert));
        }
    }
}