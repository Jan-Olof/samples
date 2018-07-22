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
            //_connString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=FunctionalSamples;";
            _connString = "Data Source=localhost\\sql2017;Initial Catalog=FunctionalSamples;Integrated Security=True;"; // TODO: Move
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
            return transfer.Handle(_now, _connString).Match(
                Invalid: BadRequest,
                Valid: result => result.Match(
                    Exception: OnFaulted,
                    Success: _ => Ok()));
        }

        private IActionResult OnFaulted(Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, Errors.UnexpectedError);
        }
    }
}