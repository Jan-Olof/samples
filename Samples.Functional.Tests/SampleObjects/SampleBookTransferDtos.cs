using Samples.Functional.Transfer;
using System;

namespace Samples.Functional.Tests.SampleObjects
{
    public static class SampleBookTransferDtos
    {
        public static BookTransferDto CreateBookTransferDto(DateTime date, string bic = "bicbac1bec9")
            => new BookTransferDto(
                10000,
                "bla",
                bic,
                date,
                "853a2670-506b-4dcf-8cda-79f2f58d1f92",
                "CH56 0483 5012 3456 7800 9",
                55,
                "ref",
                new DateTime(2018, 6, 1, 7, 8, 9));

        public static BookTransferDto CreateBookTransferDto()
            => new BookTransferDto(0, "", "", new DateTime(), "", "", 0, "", new DateTime());
    }
}