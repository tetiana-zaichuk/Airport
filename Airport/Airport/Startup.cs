using AutoMapper;
using BusinessLayer.Services;
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
            services.AddScoped<AircraftService>();
            services.AddScoped<AircraftTypeService>();
            services.AddScoped<CrewService>();
            services.AddScoped<DepartureService>();
            services.AddScoped<FlightService>();
            services.AddScoped<PilotService>();
            services.AddScoped<StewardessService>();
            services.AddScoped<TicketService>();

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
