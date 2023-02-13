namespace ApiParticipantes.WebApi.DTOs
{
    public class ParticipanteDTO
    {
        public int Id { get; set; }
        public DateTime? DataParticipacao { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public int? CodigoEvento { get; set; }
    }
}
