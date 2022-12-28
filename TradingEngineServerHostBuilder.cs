using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingEngineServer.Core.Configuration;
using TradingEngineServer.Log;
using TradingEngineServer.Log.LoggingConfiguration;

namespace TradingEngineServer.Core
{
    public sealed class TradingEngineServerHostBuilder
    {
        public static IHost BuildTradingEngineServer() => Host.CreateDefaultBuilder().ConfigureServices((ctx, services) => {
            services.AddOptions();
            services.Configure<TradingEngineServerConfiguration>(ctx.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));
            services.Configure<LogConfiguration>(ctx.Configuration.GetSection(nameof(LogConfiguration)));

            services.AddSingleton<ITradingEngineServer, TradingEngineServer>();
            services.AddSingleton<ITextLogger, TextLogger>();

            services.AddHostedService<TradingEngineServer>();
        }).Build();
    }
}
