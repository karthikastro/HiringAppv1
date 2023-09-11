using HiringAppv1._5.Models;
using HiringAppv1._5.Services;
using Microsoft.AspNetCore.Mvc;


namespace HiringAppv1._5.Controllers
{
    [ApiController]
    [Route("api/v1/candidate")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidatesServices candidateServices;

        public CandidatesController(ICandidatesServices candidateServices)
        {
            this.candidateServices = candidateServices;
        }
        [HttpGet]
        public ActionResult<List<Candidates>> Get()
        {
            try {

                return candidateServices.Get();
            }
            catch(Exception ex) { 
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try {
                var candidate = candidateServices.Get(id);
                if (candidate == null)
                {
                    return NotFound($"Student with id : {id} not found");
                }
                return Ok(candidate);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost]
        public ActionResult Post([FromBody] PostCandidateDTO candidateDTO)
        {
            try {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Candidates candidate = new Candidates();

               
                candidate.Name = candidateDTO.Name;
                candidate.JobType=candidateDTO.JobType;
                candidate.CreatedBy = candidateDTO.CreatedBy;
                candidate.UpdatedBy = candidateDTO.UpdatedBy;
                candidate.email = candidateDTO.email;
                candidate.MobileNo= candidateDTO.MobileNo;
                candidate.OverallStatus=candidateDTO.OverallStatus;
                candidate.CreatedDate = DateTime.UtcNow;
                candidate.UpdatedDate = DateTime.UtcNow;
                candidate.AddForLater = candidateDTO.AddForLater;
                candidateServices.Create(candidate);

                return Ok(candidate);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPatch("{id}")]
        public ActionResult Put(string id, [FromBody] UpdateCandidteDTO updcandidate)
        {
            try {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var existcandidate = candidateServices.Get(id);
                if (existcandidate == null)
                {
                    return NotFound("candidate not found");
                }
                Console.WriteLine(existcandidate);

                Candidates candidate = new Candidates();
                candidate.Id = id;
                candidate.Name = updcandidate.Name != null ? updcandidate.Name : existcandidate.Name;
                candidate.email = updcandidate.email != null ? updcandidate.email : existcandidate.email;
                candidate.MobileNo = updcandidate.MobileNo != null ? updcandidate.MobileNo : existcandidate.MobileNo;
                candidate.JobType = updcandidate.JobType != null ? updcandidate.JobType : existcandidate.JobType;
                candidate.OverallStatus = updcandidate.OverallStatus != 0? updcandidate.OverallStatus : existcandidate.OverallStatus;
                candidate.CreatedBy = updcandidate.CreatedBy != null ? updcandidate.CreatedBy : existcandidate.CreatedBy;
                candidate.CreatedDate = existcandidate.CreatedDate;
                candidate.UpdatedDate = DateTime.UtcNow;
                candidate.UpdatedBy = updcandidate.UpdatedBy != null ? updcandidate.UpdatedBy : existcandidate.UpdatedBy;
                candidate.AddForLater = updcandidate.AddForLater != null ? updcandidate.AddForLater : existcandidate.AddForLater;

                candidateServices.Update(id, candidate);

                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try {
                var existcandidate = candidateServices.Get(id);
                if (existcandidate == null)
                {
                    return NotFound("candidate not found");
                }
                candidateServices.Remove(id);
                return Ok($"Candidate with id :{id}    is deleted ");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
