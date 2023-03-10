using Application.DTO;
using Application.Goals;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace API.Controllers
{
    public class GoalsController : BaseController
    {
        [HttpGet]
        [Description("Gets list of all goals")]
        public async Task<IActionResult> GetGoals()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpDelete("{goalId}")]
        [Description("Gets goal in detailed view")]
        public async Task<IActionResult> DeleteGoal(Guid goalId)
        {
            return HandleResult(await Mediator.Send(new Delete.Command() { GoalId = goalId }));
        }

        [HttpPut("{goalId}")]
        [Description("Updates specified goal")]
        public async Task<IActionResult> EditGoal(GoalDto newGoal)
        {
            return HandleResult(await Mediator.Send(new Edit.Command() { NewGoal = newGoal }));
        }

        [HttpPost]
        [Description("Creates new goal")]
        public async Task<IActionResult> CreateGoal(GoalDto newGoal)
        {
            return HandleResult(await Mediator.Send(new Create.Command() { NewGoal = newGoal }));
        }
    }
}