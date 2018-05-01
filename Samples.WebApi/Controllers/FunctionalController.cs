using Dapper;
using LaYumba.Functional;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samples.Functional;
using System;
using System.Text.RegularExpressions;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace Samples.WebApi.Controllers
{
    /// <summary>
    /// This is a controller for trying out functional programming.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Functional")]
    public class FunctionalController : Controller
    {
        private static readonly Regex regex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$"); // bic code validation

        private string connString; // persistence

        private ILogger<FunctionalController> logger;

        private DateTime now; // date validation

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalController" /> class.
        /// </summary>
        public FunctionalController()
        {
            // TODO: Inject what is needed here.
        }

        /// <summary>
        /// Make a transfer.
        /// </summary>
        [HttpPost]
        public IActionResult MakeFutureTransfer([FromBody] BookTransfer request)
            => Handle(request).Match(
                Invalid: BadRequest,
                Valid: result => result.Match(
                    Exception: OnFaulted,
                    Success: _ => Ok()));

        private Validation<Exceptional<Unit>> Handle(BookTransfer request)
            => Validate(request)
                .Map(Save);

        private IActionResult OnFaulted(Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(500, Errors.UnexpectedError);
        }

        // persistence
        private Exceptional<Unit> Save(BookTransfer transfer)
        {
            try
            {
                ConnectionHelper.Connect(connString
                    , c => c.Execute("INSERT ...", transfer));
            }
            catch (Exception ex) { return ex; }
            return Unit();
        }

        private Validation<BookTransfer> Validate(BookTransfer cmd)
                    => ValidateBic(cmd).Bind(ValidateDate);

        // bic code validation
        private Validation<BookTransfer> ValidateBic(BookTransfer cmd)
        {
            if (!regex.IsMatch(cmd.Bic.ToUpper()))
                return Errors.InvalidBic;
            return cmd;
        }

        // date validation
        private Validation<BookTransfer> ValidateDate(BookTransfer cmd)
        {
            if (cmd.Date.Date <= now.Date)
                return Errors.TransferDateIsPast;
            return cmd;
        }
    }
}