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
        private ResponseDTO _responseDto;

        public CapstoneTopicsController(ICapstoneTopicService capstoneTopicService)
        {
            _capstoneTopicService = capstoneTopicService;
            _responseDto = new ResponseDTO();
        }

        // GET: api/CapstoneTopics
        [HttpGet]
        public async Task<ResponseDTO> GetCapstoneTopics()
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
        public async Task<ResponseDTO> GetCapstoneTopic(int id)
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
        [HttpPatch("{id}")]
        public async Task<ResponseDTO> ApproveTopic(int id, int status)
        {
            try
            {
                CapstoneTopicDTO capstoneTopicDTO = await _capstoneTopicService.ApproveTopic(id,status);
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

        // DELETE: api/CapstoneTopics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCapstoneTopic(int id)
        {

            return NoContent();
        }

    }
}
