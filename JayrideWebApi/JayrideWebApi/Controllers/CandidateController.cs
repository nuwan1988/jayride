using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Layer;

namespace JayrideWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly Candidate _candidateInfo;
        public CandidateController()
        {
            _candidateInfo = new Candidate();
        }

        [HttpGet("/candidate")]
        public IActionResult CandidateInfo()
        {
            var results = _candidateInfo.GetCandidate();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }
    }
}
