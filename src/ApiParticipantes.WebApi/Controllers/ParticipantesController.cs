using ApiParticipantes.Domain.Interfaces;
using ApiParticipantes.Domain.Models;
using ApiParticipantes.WebApi.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.InteropServices;

namespace ApiParticipantes.WebApi.Controllers
{
    public class ParticipantesController : ParticipantesControllerBase
    {
        private readonly ParticipanteService _participanteService;
        private readonly IRepository<Participante> _participanteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ParticipantesController(ParticipanteService participanteService, IRepository<Participante> participanteRepository, IUnitOfWork unitOfWork)
        {
            _participanteService = participanteService;
            _participanteRepository = participanteRepository;
            _unitOfWork = unitOfWork;
        }

        static Mapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParticipanteDTO, Participante>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Participante>> GetParticipante(int id)
        {
            var participante = _participanteRepository.GetById(id);
            if(participante == null)
            {
                return NotFound(new {message = $"Participante com o id {id} não foi encontrado."});
            }
            return Ok(participante);
        }

        [HttpGet()]
        public async Task<ActionResult<Participante>> GetParticipantes(int limit)
        {
            if(limit > 0)
            {
                var participantesLimited = _participanteRepository.GetLimit(limit);
                return Ok(participantesLimited);
            }
            var participantes = _participanteRepository.GetAll();
            return Ok(participantes);
        }

        [HttpPost()]
        public async Task<ActionResult> NewParticipante([FromBody]ParticipanteDTO newParticipante)
        {
            var mapper = InitializeAutoMapper();
            var entity = mapper.Map<Participante>(newParticipante);
            await _participanteService.Save(newParticipante.DataParticipacao, newParticipante.Nome, newParticipante.Cpf, newParticipante.CodigoEvento);
            _unitOfWork.Commit();
            return Ok();
        }

        [HttpPut()]
        public async Task<ActionResult> EditParticipante([FromBody] ParticipanteDTO newParticipante)
        {
            var mapper = InitializeAutoMapper();
            var entity = mapper.Map<Participante>(newParticipante);
            var participante = _participanteRepository.GetById(newParticipante.Id);
            if (participante == null)
                return NotFound(new { message = $"Participante com o id {newParticipante.Id} não foi encontrado." });
            await _participanteService.Update(newParticipante.Id, newParticipante.DataParticipacao, newParticipante.Nome, newParticipante.Cpf, newParticipante.CodigoEvento);
            _unitOfWork.Commit();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParticipante(int id)
        {
            var participante = _participanteRepository.GetById(id);
            if (participante == null)
                return NotFound(new { message = $"Participante com o id {id} não foi encontrado." });
            await _participanteService.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
