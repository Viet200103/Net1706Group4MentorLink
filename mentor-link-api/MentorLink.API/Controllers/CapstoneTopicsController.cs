using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MentorLink.Data.Models;
using MentorLink.Business.Services.IService;
using MentorLink.Data.Models.Dtos;
using MentorLink.Business.DTOs;

namespace MentorLink.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapstoneTopicsController : ControllerBase
    {
        private readonly ICapstoneTopicService _capstoneTopicService;
        private ResponseDto _responseDto;

        public CapstoneTopicsController(ICapstoneTopicService capstoneTopicService)
        {
            _capstoneTopicService = capstoneTopicService;
            _responseDto = new ResponseDto();
        }

        // GET: api/CapstoneTopics
        [HttpGet]
        public async Task<ResponseDto> GetCapstoneTopics()
        {
            try
            {
                IEnumerable<CapstoneTopicDTO> newsList = await _capstoneTopicService.GetCapstoneTopics();
                _responseDto.Result = newsList;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        // GET: api/CapstoneTopics/5
        [HttpGet("{id}")]
        public async Task<ResponseDto> GetCapstoneTopic(int id)
        {

            try
            {
                var capstoneTopic = await _capstoneTopicService.GetCapstoneTopicById(id);
                _responseDto.Result = capstoneTopic;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        // PUT: api/CapstoneTopics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<ResponseDto> ApproveTopic(CapstoneTopicDTO capstoneTopic)
        {
            try
            {
                CapstoneTopicDTO capstoneTopicDTO = await _capstoneTopicService.ApproveTopic(capstoneTopic);
                _responseDto.Result = capstoneTopicDTO;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;
        }

        // POST: api/CapstoneTopics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CapstoneTopic>> PostCapstoneTopic(CapstoneTopic capstoneTopic)
        {
           

            return CreatedAtAction("GetCapstoneTopic", new { id = capstoneTopic.CapstoneTopicId }, capstoneTopic);
        }

        // DELETE: api/CapstoneTopics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCapstoneTopic(int id)
        {

            return NoContent();
        }

    }
}
