using System;
using System.Threading.Tasks;
using CRUDRepository;
using CRUDRepository.Interface;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TechnicalRiskAssessmentFuncApp;

[assembly: FunctionsStartup(typeof(Startup))]
namespace TechnicalRiskAssessmentFuncApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ICrudReposetory, CRUDReposetory>();
        }
    }
}