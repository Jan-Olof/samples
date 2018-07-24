﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samples.Functional.Helpers;
using Samples.Functional.Transfer;
using System;
using System.Net;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferController" /> class.
        /// </summary>
        public TransferController(ILogger<TransferController> logger, Func<SqlTemplate, BookTransferDao, int> commands, Func<DateTime> now)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commands = commands;
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