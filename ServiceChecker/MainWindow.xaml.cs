
using System.Windows;


namespace ServiceChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ServiceLoaded(object sender, RoutedEventArgs args)
        {
            ViewModel.ServiceViewModel viewModel = new ViewModel.ServiceViewModel();
            ServiceControl.DataContext = viewModel;
        }
    }
}
