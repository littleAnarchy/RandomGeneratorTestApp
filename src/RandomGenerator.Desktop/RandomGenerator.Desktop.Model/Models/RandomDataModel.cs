using RandomGenerator.Desktop.Model.Common;
using RandomGenerator.Desktop.Model.Interfaces;
using RandomGenerator.Desktop.Model.Services;
using System;
using System.Threading;


namespace RandomGenerator.Desktop.Model.Models
{
    public class RandomDataModel : BaseNotificatable, IDisposable
    {
        private readonly RandomDataService _dataService;

        private int _value;
        public int Value 
        { 
            get => _value; 
            set 
            {
                _value = value;
                RaisePropertyChanged(nameof(Value));    
            } 
        }

        private bool _isDataGenerating;
        public bool IsDataGenerating 
        {
            get => _isDataGenerating;
            set 
            {
                _isDataGenerating = value;
                RaisePropertyChanged(nameof(IsDataGenerating));
            }
        }

        public RandomDataModel(IRandomGeneratorService generator)
        {
            _dataService = new RandomDataService(generator);
            _dataService.DataGenerated += OnRandomDataGenerated;
            _dataService.GenerationStopped += OnGenerationStopped;
        }

        public void StartGenerate(CancellationToken token)
        {
            _dataService.StartGenerateData(token);
            IsDataGenerating = true;
        }

        private void OnRandomDataGenerated(int value)
        {
            Value = value;
        }

        private void OnGenerationStopped()
        {
            IsDataGenerating = false;
        }

        public void Dispose()
        {
            _dataService.DataGenerated -= OnRandomDataGenerated;
            _dataService.GenerationStopped -= OnGenerationStopped;
        }
    }
}
