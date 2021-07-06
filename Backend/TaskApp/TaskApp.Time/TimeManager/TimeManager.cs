using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Messaging.Infrastructure;
using Serilog;
using TaskApp.Time.Events;

namespace TaskApp.Time.TimeManager
{
    public class TimeManager : IHostedService
    {
        DateTime _lastCheck;
        CancellationTokenSource _cancellationTokenSource;
        Task _task;
        IMessagePublisher _messagePublisher;

        public TimeManager(IMessagePublisher messagePublisher)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _lastCheck = DateTime.Now;
            _messagePublisher = messagePublisher;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _task = Task.Run(() => Worker(), _cancellationTokenSource.Token);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }

        private async void Worker()
        {
            while (true)
            {
                if (DateTime.Now.Subtract(_lastCheck).Days > 0)
                {
                    Log.Information($"Day has passed!");
                    _lastCheck = DateTime.Now;
                    DateTime passedDay = _lastCheck.AddDays(-1);
                    DayHasPassed e = new DayHasPassed();
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");
                }
                Thread.Sleep(10000);
            }
        }
    }
}
