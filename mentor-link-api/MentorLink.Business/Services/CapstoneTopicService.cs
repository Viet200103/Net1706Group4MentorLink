using AutoMapper;
using MentorLink.Business.DTOs;
using MentorLink.Business.Services.IService;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MentorLink.Business.Services
{
    public class CapstoneTopicService : ICapstoneTopicService
    {
        private readonly ICapstoneTopicRepository _capstoneTopicRepository;
        private readonly IMapper _mapper;

        public CapstoneTopicService(ICapstoneTopicRepository capstoneTopicRepository, IMapper mapper)
        {
            _capstoneTopicRepository = capstoneTopicRepository;
            _mapper = mapper;
        }

        public async Task<CapstoneTopicDTO> ApproveTopic(CapstoneTopicDTO capstoneTopicDTO)
        {      
            CapstoneTopic capstoneTopic = await _capstoneTopicRepository.ApproveTopic(_mapper.Map<CapstoneTopic>(capstoneTopicDTO));
            return _mapper.Map<CapstoneTopicDTO>(capstoneTopic);
        }
         
        public Task<CapstoneTopicDTO> CreateCapstoneTopicAsync(CapstoneTopicDTO capstoneTopicDTO)
        {
            //CapstoneTopic capstoneTopic = new CapstoneTopic();
            //capstoneTopic.CapstoneTopicId = capstoneTopicDTO.CapstoneTopicId;
            //capstoneTopic.Title = capstoneTopicDTO.Title;
            //capstoneTopic.SendTime = capstoneTopicDTO.SendTime;
            //capstoneTopic.Status = capstoneTopicDTO.Status;
            //capstoneTopic.ResponseBy = capstoneTopicDTO.ResponseBy;
            //capstoneTopic.ResponseTime = capstoneTopicDTO.ResponseTime;
            //capstoneTopic.ResponseMessage = capstoneTopicDTO.ResponseMessage;
            return null;       }

        public Task<bool> DeleteCapstoneTopicAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CapstoneTopicDTO>> GetCapstoneTopics()
        {
            IEnumerable<CapstoneTopic> capstoneTopicList = await _capstoneTopicRepository.GetAllCapstoneTopicAsync();
           
            return _mapper.Map<IEnumerable<CapstoneTopicDTO>>(capstoneTopicList);
        }

        public async Task<CapstoneTopicDTO> GetCapstoneTopicById(int id)
        {
            CapstoneTopic capstoneTopic = await _capstoneTopicRepository.GetCapstoneTopicById(id);

            if (capstoneTopic == null)
            {
                throw new InvalidOperationException("News not found");
            }

           

            return _mapper.Map<CapstoneTopicDTO>(capstoneTopic);
        }
        private string DeserializeContent(string jsonContent)
        {
            try
            {
                var jsonObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);
                return jsonObject?["body"] ?? string.Empty;
            }
            catch
            {
                return jsonContent;
            }
        }
    }
}
