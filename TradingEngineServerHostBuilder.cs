using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingEngineServer.Core.Configuration;

namespace TradingEngineServer.Core
{
    public sealed class TradingEngineServerHostBuilder
    {
        public static IHost BuildTradingEngineServer() => Host.CreateDefaultBuilder().ConfigureServices((ctx, services) => {
            services.AddOptions();
            services.Configure<TradingEngineServerConfiguration>(ctx.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));

            services.AddSingleton<ITradingEngineServer, TradingEngineServer>();

            services.AddHostedService<TradingEngineServer>();
        }).Build();
    }
}
