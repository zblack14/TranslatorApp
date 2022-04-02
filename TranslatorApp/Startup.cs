using Amazon.Translate;
using Microsoft.AspNetCore.Mvc;
using TranslatorApp.Core;

namespace TranslatorApp.Setup
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // Add framework services.
            services.AddMvc();

            //Add default options
            services.AddDefaultAWSOptions(_configuration.GetAWSOptions());

            //Add Managers to service
            services.AddSingleton<ITranslationManager, TranslationManager>();

            //Add Repositories to service
            services.AddSingleton<ITranslationRepository, TranslationRepository>();

            //Add aws services
            services.AddAWSService<IAmazonTranslate>();
        }
    }
}