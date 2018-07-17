using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samples.Functional.Transfer;
using System;
using System.Net;

namespace Samples.FunctionalWebApi.Controllers
{
    /// <summary>
    /// This is a controller for trying out functional programming.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Functional")]
    public class FunctionalController : Controller
    {
        private readonly string _connString; // persistence

        private readonly ILogger<FunctionalController> _logger;

        private readonly Func<DateTime> _now; // date validation

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalController" /> class.
        /// </summary>
        public FunctionalController(ILogger<FunctionalController> logger, Func<DateTime> now)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _connString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=FunctionalSamples;";
            _now = now;
        }

        /// <summary>
        /// Make a transfer.
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public IActionResult MakeFutureTransfer([FromBody] BookTransferDto transfer)
        {
            // TODO: Fix

            return transfer.Handle(_now, _connString).Match(
                Invalid: BadRequest,
                Valid: result => result.Match(
                    Exception: OnFaulted,
                    Success: _ => Ok()));

            //return Ok();
        }

        //private Validation<Exceptional<Unit>> Handle(BookTransfer request)
        //    => Validate(request)
        //        .Map(Save);

        private IActionResult OnFaulted(Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, Errors.UnexpectedError);
        }

        //// persistence
        //private Exceptional<Unit> Save(BookTransfer transfer)
        //{
        //    try
        //    {
        //        ConnectionHelper.Connect(_connString, c => c.Execute("INSERT ...", transfer));
        //    }
        //    catch (Exception ex) { return ex; }
        //    return Unit();
        //}

        //private Validation<BookTransfer> Validate(BookTransfer cmd)
        //    => cmd.ValidateBic(Settings.BicCodeRegex())
        //        .Bind(c => c.ValidateDate(_now));
    }
}