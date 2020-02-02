using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace MeterReaderWeb.Services
{
    public class MeterService : MeterReadingService.MeterReadingServiceBase
    {
        private ILogger<MeterService> _logger;

        public MeterService(ILogger<MeterService> logger)
        {
            _logger = logger;
        }
        public override Task<StatusMessage> AddReading(ReadingPacket request, ServerCallContext context)
        {
            var result = new StatusMessage()
            {
                Success = ReadingStatus.Failure
            };

            if(request.Successful == ReadingStatus.Success)
            {
                try
                {
                    foreach (var reading in request.Readings)
                    {
                        // Save to database
                    }
                }
                catch (Exception ex)
                {

                    result.Message = $"Exception: {ex.Message}";
                }
            }

            return Task.FromResult(result);
        }
    }
}
