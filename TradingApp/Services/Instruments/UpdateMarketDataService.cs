//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace TradingApp.Services.Instrument
//{
//    public class UpdateMarketDataService : BackgroundService
//    {
//        private readonly ILogger<UpdateMarketDataService> _logger;
//        private readonly OrderingBackgroundSettings _settings;

//        private readonly IEventBus _eventBus;

//        public UpdateMarketDataService(ILogger<UpdateMarketDataService> logger)
//        {
//            //Constructor’s parameters validations...      
//        }

//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            _logger.LogDebug($"UpdateMarketDataService is starting.");

//            stoppingToken.Register(() =>
//                    _logger.LogDebug($" UpdateMarketDataService background task is stopping."));

//            while (!stoppingToken.IsCancellationRequested)
//            {
//                _logger.LogDebug($"UpdateMarketDataService task doing background work.");

//                // This eShopOnContainers method is quering a database table 
//                // and publishing events into the Event Bus (RabbitMS / ServiceBus)
//                CheckConfirmedGracePeriodOrders();

//                await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
//            }

//            _logger.LogDebug($"UpdateMarketDataService background task is stopping.");
//        }

//        protected override async Task StopAsync(CancellationToken stoppingToken)
//        {
//            // Run your graceful clean-up actions
//        }
//    }
//}
