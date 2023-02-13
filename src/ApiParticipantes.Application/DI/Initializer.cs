using ApiParticipantes.Domain.Interfaces;
using ApiParticipantes.Domain.Models;
using ApiParticipantes.Infra.Context;
using ApiParticipantes.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiParticipantes.Application.DI
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection));
            services.AddScoped(typeof(ParticipanteService));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<Participante>), typeof(Repository<Participante>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
