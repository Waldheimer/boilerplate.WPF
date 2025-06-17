using Apmt_WPF.Features.Appointments;
using Apmt_WPF.Features.Dashboard;
using Apmt_WPF.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace Apmt_WPF.Features.MainWindow
{
    public partial class MainWindowViewModel : ObservableRecipient
    {
        private readonly NavigationService<DashboardViewModel> _navigationServiceDashboard;
        private readonly NavigationService<AppointmentsViewModel> _navigationServiceAppointments;
        private readonly NavigationManager _navigationManager;

        public ObservableRecipient? CurrentViewModel => _navigationManager.CurrentViewModel;

        public MainWindowViewModel(NavigationManager navigationManager, 
            NavigationService<DashboardViewModel> navigationServiceDashboard, 
            NavigationService<AppointmentsViewModel> navigationServiceAppointments)
        {
            _navigationManager = navigationManager;
            _navigationManager.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationServiceDashboard = navigationServiceDashboard;
            _navigationServiceAppointments = navigationServiceAppointments;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        [RelayCommand]
        public void NavigateDashboard()
        {
            this._navigationServiceDashboard.Navigate();
        }
        [RelayCommand]
        public void NavigateAppointments()
        {
            this._navigationServiceAppointments.Navigate();
        }
    }
}
