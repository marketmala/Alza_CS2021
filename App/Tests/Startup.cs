using Alza_API.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Tests.Data;

namespace Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) => services
            .AddSingleton<IDataContext, DataContextMock>();
    }
}
