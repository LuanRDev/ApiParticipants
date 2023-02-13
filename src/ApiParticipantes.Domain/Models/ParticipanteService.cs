using ApiParticipantes.Domain.Interfaces;

namespace ApiParticipantes.Domain.Models
{
    public class ParticipanteService
    {
        private readonly IRepository<Participante> _participanteRepository;
        public ParticipanteService(IRepository<Participante> participanteRepository)
        {
            _participanteRepository = participanteRepository;
        }

        public async Task Save(DateTime? dataParticipacao, string? nome, string? cpf, int? codigoEvento)
        {
            Participante participante = new(dataParticipacao, nome, cpf, codigoEvento);
            await _participanteRepository.Save(participante);
        }

        public async Task Update(int codigoParticipante, DateTime? dataParticipacao, string? nome, string? cpf, int? codigoEvento)
        {
            var participante = _participanteRepository.GetById(codigoParticipante);
            if(participante != null)
            {
                participante.UpdateParticipante(dataParticipacao, nome, cpf, codigoEvento);
                await _participanteRepository.Update(participante);
            }
        }

        public async Task Delete(int codigoParticipante)
        {
            var participante = _participanteRepository.GetById(codigoParticipante);
            if(participante != null) 
            {
                await _participanteRepository.Delete(participante.Id);
            }
        }
    }
}
