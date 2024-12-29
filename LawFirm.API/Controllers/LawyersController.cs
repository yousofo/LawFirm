using LawFirm.Application;
using LawFirm.Application.Lawyers.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LawFirm.API.Controllers
{
    [ApiController]
    [Route("api/lawyers")]
    public class LawyersController(LawyersService lawyersService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetLawyers()
        {
            var lawyers = await lawyersService.GetLawyers();
            return Ok(lawyers);
        }




        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLawyer(int id)
        {
            var lawyer = await lawyersService.GetLawyer(id);
            if (lawyer == null)
            {
                return NotFound();
            }
            return Ok(lawyer);
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLawyer(int id)
        {
            bool deleted= await lawyersService.DeleteLawyer(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> CreateLawyer([FromBody] LawyerDto lawyerDto)
        {
            int id = await lawyersService.CreateLawyer(lawyerDto);
            return CreatedAtAction(nameof(GetLawyer), new {id},null);


        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLawyer(int id,[FromBody] LawyerDto lawyerDto)
        {
            int _id = await lawyersService.UpdateLawyer(lawyerDto);
            if(_id < 0)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
