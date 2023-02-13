namespace ApiParticipantes.Domain.Models
{
    public class Participante : BaseEntity
    {
        public DateTime? DataParticipacao { get; private set; }
        public string? Nome { get; private set; }
        public string? Cpf { get; private set; }
        public int? CodigoEvento { get; private set; }

        public Participante(DateTime? dataParticipacao, string? nome, string? cpf, int? codigoEvento)
        {
            ValidaParticipante(dataParticipacao, nome, cpf, codigoEvento);
            DataParticipacao = dataParticipacao;
            Nome = nome;
            Cpf = cpf;
            CodigoEvento = codigoEvento;
        }
        public Participante() { }

        public void UpdateParticipante(DateTime? dataParticipacao, string? nome, string? cpf, int? codigoEvento)
        {
            if(dataParticipacao != null)
            {
                DataParticipacao = dataParticipacao;
            }
            if(nome != null)
            {
                Nome = nome;
            }
            if(cpf != null)
            {
                Cpf = cpf;
            }
            if(codigoEvento != null)
            {
                CodigoEvento = codigoEvento;
            }
        }

        private void ValidaParticipante(DateTime? dataParticipacao, string? nome, string? cpf, int? codigoEvento)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new InvalidOperationException("O campo nome não pode ser nulo ou vazio");
            }
            if(string.IsNullOrEmpty(cpf))
            {
                throw new InvalidOperationException("O campo cpf não pode ser nulo ou vazio");
            }
            if(dataParticipacao == null) 
            {
                throw new InvalidOperationException("O campo Data participação não pode ser nulo ou vazio");
            }
            if(codigoEvento == null)
            {
                throw new InvalidOperationException("O campo codigo evento não pode ser nulo ou vazio");
            }
        }
    }
}
