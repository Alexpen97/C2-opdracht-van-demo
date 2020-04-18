using BikeRentalDemo.ViewModels;
using System.Windows;

namespace BikeRentalDemo.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
