using RandomGenerator.Desktop.Model.Models;
using RandomGenerator.Desktop.Model.Services;
using RandomGenerator.Desktop.ViewModel;
using RandomGenerator.Desktop.Views;

namespace RandomGenerator.Desktop.View
{
    internal static class CompositionRoot
    {
        public static MainWindow Composite()
        {
            var generator = new WebRandomGeneratorService("https://localhost:44397/random/get");
            var randomDataModel = new RandomDataModel(generator);
            var randomDataViewModel = new RandomDataViewModel(randomDataModel);
            return new MainWindow(randomDataViewModel);
        }
    }
}
