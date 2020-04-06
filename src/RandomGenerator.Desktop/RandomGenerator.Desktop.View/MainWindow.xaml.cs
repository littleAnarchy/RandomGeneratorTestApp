using RandomGenerator.Desktop.ViewModel;
using System.Threading;
using System.Windows;

namespace RandomGenerator.Desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(RandomDataViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
