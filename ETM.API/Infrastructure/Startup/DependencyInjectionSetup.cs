using ETM.API.Infrastructure.Interfaces;
using ETM.API.Infrastructure.Mapper;
using ETM.API.Repository.Services;
using ETM.API.Service.Interfaces;
using ETM.API.Service.Services;

namespace ETM.API.Infrastructure.Startup
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddAutoMapper(typeof(ETMProfile));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
