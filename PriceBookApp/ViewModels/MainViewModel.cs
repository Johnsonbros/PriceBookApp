using System.ComponentModel;
using System.Windows.Input;
using PriceBookApp.Helpers;

namespace PriceBookApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object? _currentView; // Make it nullable
        public object? CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged("CurrentView"); }
        }

        public ICommand NavigateCommand { get; set; }

        public MainViewModel()
        {
            NavigateCommand = new RelayCommand(Navigate);
            CurrentView = new HomeViewModel();
        }

        private void Navigate(object? viewName) // Make parameter nullable
        {
            switch (viewName)
            {
                case "HomeView":
                    CurrentView = new HomeViewModel();
                    break;
                case "ImportExportView":
                    CurrentView = new ImportExportViewModel();
                    break;
                case "PricingDataView":
                    CurrentView = new PricingDataViewModel();
                    break;
                case "CalculationsView":
                    CurrentView = new CalculationsViewModel();
                    break;
                case "SettingsView":
                    CurrentView = new SettingsViewModel();
                    break;
                case "HelpView":
                    CurrentView = new HelpViewModel();
                    break;
                default:
                    CurrentView = null;
                    break;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged; // Make it nullable
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
