using RandomGenerator.Desktop.Model.Common;
using RandomGenerator.Desktop.Model.Models;
using RandomGenerator.Desktop.ViewModel.Common;
using System.ComponentModel;
using System.Threading;

namespace RandomGenerator.Desktop.ViewModel
{
    public class RandomDataViewModel : BaseNotificatable
    {
        private readonly RandomDataModel _model;
        private CancellationTokenSource _tokenSource;
        public int Value => _model.Value;

        public CommandHandler StartGenerateCommand { get; }
        public CommandHandler StopGenerateCommand { get; }

        public RandomDataViewModel(RandomDataModel model)
        {
            _model = model;
            _model.PropertyChanged += OnPropertyChanged;
            StartGenerateCommand = new CommandHandler(parameter => !_model.IsDataGenerating, StartGenerateData);
            StopGenerateCommand = new CommandHandler(parameter => _model.IsDataGenerating, parameter => _tokenSource.Cancel());
        }

        private void StartGenerateData(object parameter)
        {
            _tokenSource = new CancellationTokenSource();
            _model.StartGenerate(_tokenSource.Token);
        }

        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(sender, args);

            //this part fix bug with buttons IsEnabled change stucking (stopping occurs not in handler context and button stuck until focus will be changed)
            StartGenerateCommand?.RaiseCanExecuteChanged();
            StopGenerateCommand?.RaiseCanExecuteChanged();
        }
    }
}
