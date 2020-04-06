using RandomGenerator.Desktop.Model.Interfaces;
using System;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace RandomGenerator.Desktop.Model.Services
{
    internal class RandomDataService : IDisposable
    {
        private readonly IRandomGeneratorService _generator;
        private readonly Timer _timer;

        private CancellationToken _token;

        public event Action<int> DataGenerated;
        public event Action GenerationStopped;

        public RandomDataService(IRandomGeneratorService generator)
        {
            _generator = generator;
            _timer = new Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            _timer.Elapsed += OnTimerTick;
        }

        public void StartGenerateData(CancellationToken token)
        {
            if (_timer.Enabled)
                throw new Exception("Receiving has been already started");
            _token = token;
            _timer.Enabled = true;
            _timer.Start();
        }

        private void StopGenerate()
        {
            _timer.Stop();
            _timer.Enabled = false;
            GenerationStopped?.Invoke();
        }

        private async void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            if (_token.IsCancellationRequested)
            {
                StopGenerate();
                return;
            }

            var randomValue = await _generator.GetRandomValueAsync();
            DataGenerated?.Invoke(randomValue);
        }

        public void Dispose()
        {
            StopGenerate();
            _timer.Elapsed -= OnTimerTick;
            _timer.Close();
            _timer.Dispose();
        }
    }
}
