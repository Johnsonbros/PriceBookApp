using System.Windows;
using PriceBookApp.ViewModels;

namespace PriceBookApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
