using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<DataSeends>();
            services.AddScoped<IRepository<Aircraft>, Repository<Aircraft>>();
            services.AddScoped<IRepository<AircraftType>, Repository<AircraftType>>();
            services.AddScoped<IRepository<Crew>, Repository<Crew>>();
            services.AddScoped<IRepository<Departure>, Repository<Departure>>();
            services.AddScoped<IRepository<Flight>, Repository<Flight>>();
            services.AddScoped<IRepository<Pilot>, Repository<Pilot>>();
            services.AddScoped<IRepository<Stewardess>, Repository<Stewardess>>();
            services.AddScoped<IRepository<Ticket>, Repository<Ticket>>();
            services.AddScoped<IService<Shared.DTO.Aircraft>, AircraftService>();
            services.AddScoped<IService<Shared.DTO.AircraftType>, AircraftTypeService>();
            services.AddScoped<IService<Shared.DTO.Crew>, CrewService>();
            services.AddScoped<IService<Shared.DTO.Departure>, DepartureService>();
            services.AddScoped<IService<Shared.DTO.Flight>, FlightService>();
            services.AddScoped<IService<Shared.DTO.Pilot>, PilotService>();
            services.AddScoped<IService<Shared.DTO.Stewardess>, StewardessService>();
            services.AddScoped<IService<Shared.DTO.Ticket>, TicketService>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Aircraft, Shared.DTO.Aircraft>();
                cfg.CreateMap<Shared.DTO.Aircraft, Aircraft>();
                cfg.CreateMap<AircraftType, Shared.DTO.AircraftType>();
                cfg.CreateMap<Shared.DTO.AircraftType, AircraftType>();
                cfg.CreateMap<Flight, Shared.DTO.Flight>();
                cfg.CreateMap<Shared.DTO.Flight, Flight>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
