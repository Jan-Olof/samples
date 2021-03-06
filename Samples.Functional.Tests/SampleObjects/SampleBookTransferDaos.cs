﻿using Samples.Functional.Transfer;
using System;
using System.Collections.Generic;

namespace Samples.Functional.Tests.SampleObjects
{
    public static class SampleBookTransferDaos
    {
        public static BookTransferDao CreateBookTransferDao(DateTime date, string bic = "bicbac1bec9")
            => new BookTransferDao(
                10000,
                "bla",
                bic,
                date,
                Guid.Parse("853a2670-506b-4dcf-8cda-79f2f58d1f92"),
                "CH56 0483 5012 3456 7800 9",
                33,
                "ref",
                new DateTime(2018, 6, 1, 7, 8, 9));

        public static BookTransferDao CreateBookTransferDao()
            => new BookTransferDao(0, "", "", new DateTime(), Guid.Empty, "", 0, "", new DateTime());

        public static IEnumerable<BookTransferDao> CreateBookTransferDaos()
            => new List<BookTransferDao> { CreateBookTransferDao(new DateTime(2018, 6, 2)) };
    }
}