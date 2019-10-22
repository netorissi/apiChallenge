using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Poll_Challenge_Api.Models;

namespace Poll_Challenge_Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class PollController : Controller
    {
        private readonly ApiContext _apiContext;

        public PollController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poll>>> Get()
        {
            return await _apiContext
                .Polls
                .Include(p => p.Options)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Poll>> Get(int id)
        {
            var poll = await _apiContext
                .Polls
                .Include(o => o.Options)
                .FirstOrDefaultAsync(p => p.PollId == id);

            if (poll == null)
            {
                return NotFound();
            }

            poll.Views++;
            _apiContext.Entry(poll).State = EntityState.Modified;
            await _apiContext.SaveChangesAsync();

            return poll;
        }

        [HttpGet("{id}/stats")]
        public async Task<ActionResult> GetStats(int id)
        {
            var poll = await _apiContext
                .Polls
                .Include(o => o.Options)
                .FirstOrDefaultAsync(p => p.PollId == id);

            if (poll == null)
            {
                return NotFound();
            }

            List<object> list = new List<object>();

            foreach (var opt in poll.Options)
            {
                var vote = await _apiContext.Votes.FirstOrDefaultAsync(v => v.OptionId == opt.OptionId);
                if (vote != null)
                {
                    list.Add(new { option_id = vote.OptionId, qty = vote.Qty });
                }
            }
            var resp = new ResponseVote
            {
                Views = (int)poll.Views,
                Votes = list
            };

            return Ok(resp);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JObject objReq)
        {
            try
            {
                Poll poll = new Poll
                {
                    PollDescription = (string)objReq["poll_description"]
                };
                _apiContext.Polls.Add(poll);
                await _apiContext.SaveChangesAsync();

                var options = objReq["options"];
        
                foreach(var opt in options)
                {
                    Option option = new Option
                    {
                        PollId = poll.PollId,
                        Description = (string)opt
                    };

                    _apiContext.Options.Add(option);
                    await _apiContext.SaveChangesAsync();

                    Vote vote = new Vote
                    {
                        OptionId = option.OptionId,
                        Qty = 0
                    };

                    _apiContext.Votes.Add(vote);
                    await _apiContext.SaveChangesAsync();
                }
                return CreatedAtAction(null, new { poll_id = poll.PollId });

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}/vote")]
        public async Task<ActionResult> PostVote(int id, [FromBody] JObject objReq)
        {
            var optId = (int)objReq["option_id"];
            var poll = await _apiContext
                .Polls
                .Include(o => o.Options)
                .Where(o => o.Options.Any(op => op.OptionId == optId))
                .FirstOrDefaultAsync(p => p.PollId == id);

            if (poll == null)
            {
                return NotFound();
            }

            var vote = await _apiContext
                .Votes
                .FirstOrDefaultAsync(v => v.OptionId == optId);

            if (vote == null)
            {
                return NotFound();
            }

            vote.Qty++;
            _apiContext.Entry(vote).State = EntityState.Modified;
            await _apiContext.SaveChangesAsync();
            return Ok();
        }
    }
}
