﻿using Application.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            return HandleResult(await Mediator.Send(new Details.Query() { AccountId = accountId }));
        }

        [HttpDelete("{accountId}")]
        public async Task<IActionResult> DeleteAccount(Guid accountId)
        {
            return HandleResult(await Mediator.Send(new Delete.Command() { AccountId = accountId }));
        }
    }
}