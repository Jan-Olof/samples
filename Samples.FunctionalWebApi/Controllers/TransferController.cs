using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samples.Functional.Helpers;
using Samples.Functional.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using static Samples.Functional.Transfer.TransferInteractor;

namespace Samples.FunctionalWebApi.Controllers
{
    /// <summary>
    /// This is a controller for trying out functional programming.
    /// </summary>
    [Produces("application/json")]
    [Route("api/transfer")]
    public class TransferController : Controller
    {
        private readonly Func<SqlTemplate, BookTransferDao, int> _commands;
        private readonly ILogger<TransferController> _logger;
        private readonly Func<DateTime> _now;
        private readonly Func<SqlTemplate, object, IEnumerable<BookTransferDao>> _queries;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferController" /> class.
        /// </summary>
        public TransferController(
            ILogger<TransferController> logger,
            Func<SqlTemplate, BookTransferDao, int> commands,
            Func<SqlTemplate, object, IEnumerable<BookTransferDao>> queries,
            Func<DateTime> now)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commands = commands;
            _queries = queries;
            _now = now;
        }

        /// <summary>
        /// Get a transfer from id.
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("{id}")]
        public IActionResult GetTransfer(int id)
            => id.GetFromId(_queries)
                .Match(
                    OnFaulted,
                    result => Ok(result.FirstOrDefault()));

        /// <summary>
        /// Get all transfers.
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public IActionResult GetTransfers()
            => GetAll(_queries)
                .Match(
                    OnFaulted,
                    Ok);

        /// <summary>
        /// Make a transfer.
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public IActionResult MakeFutureTransfer([FromBody] BookTransferDto transfer)
            => transfer
                .Create(_now, _commands)
                .Match(
                    Invalid: BadRequest,
                    Valid: result => result.Match(
                        Exception: OnFaulted,
                        Success: _ => Ok()));

        private IActionResult OnFaulted(Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, Errors.UnexpectedError);
        }
    }
}