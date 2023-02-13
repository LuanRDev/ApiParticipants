namespace ApiParticipantes.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
