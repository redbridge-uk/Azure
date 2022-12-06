using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Redbridge.Diagnostics
{
	public class StopwatchLogger : IDisposable
	{
		private readonly ILogger _logger;
		private readonly string _content;
		private readonly Stopwatch _stopwatch;

		public StopwatchLogger(ILogger logger, string format)
		{
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_content = format;
			_logger.LogInformation($"Starting {format}");
			_stopwatch = Stopwatch.StartNew();
		}

		public void Dispose()
		{
			_stopwatch.Stop();
			_logger.LogInformation($"Finishing {_content} {_stopwatch.ElapsedMilliseconds}ms ({_stopwatch.ElapsedMilliseconds / 1000}secs)");
		}
	}
}
