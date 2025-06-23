using Apmt_WPF.Features.Appointments;
using Apmt_WPF.Features.Dashboard;
using Apmt_WPF.Features.Users;
using Apmt_WPF.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Apmt_WPF.Features.MainWindow
{
    public partial class MainWindowViewModel : ObservableRecipient
    {
        private readonly UserService _userService;
        private readonly NavigationService<DashboardViewModel> _navigationServiceDashboard;
        private readonly NavigationService<AppointmentsViewModel> _navigationServiceAppointments;
        private readonly NavigationManager _navigationManager;
        //private readonly LeftContentNavigationManager _lc_navigationManager;
        //private readonly RightContentNavigationManager _rc_navigationManager;

        //public ObservableRecipient? LCCurrentViewModel => _lc_navigationManager.CurrentViewModel;
        //public ObservableRecipient? RCCurrentViewModel => _rc_navigationManager.CurrentViewModel;
        public ObservableRecipient? CurrentViewModel => _navigationManager.CurrentViewModel;

        public MainWindowViewModel(
            UserService userService,
            NavigationManager navigationManager,
            //LeftContentNavigationManager lcnavigationManager, 
            //RightContentNavigationManager rcnavigationManager,
            NavigationService<DashboardViewModel> navigationServiceDashboard, 
            NavigationService<AppointmentsViewModel> navigationServiceAppointments)
        {
            _userService = userService;
            _navigationManager = navigationManager;
            _navigationManager.CurrentViewModelChanged += OnCurrentViewModelChanged;
            //_lc_navigationManager = lcnavigationManager;
            //_lc_navigationManager.CurrentViewModelChanged += OnCurrentLCViewModelChanged;
            //_rc_navigationManager = rcnavigationManager;
            //_rc_navigationManager.CurrentViewModelChanged += OnCurrentRCViewModelChanged;
            _navigationServiceDashboard = navigationServiceDashboard;
            _navigationServiceAppointments = navigationServiceAppointments;
        }

        public void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        //private void OnCurrentLCViewModelChanged()
        //{
        //    OnPropertyChanged(nameof(LCCurrentViewModel));
        //}
        //private void OnCurrentRCViewModelChanged()
        //{
        //    OnPropertyChanged(nameof(LCCurrentViewModel));
        //}

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

        [RelayCommand]
        private async Task TestApi()
        {
            var input = new UserRegisterDto
            {
                username = "waldheimer",
                email = "whm@whm.com",
                password = "whm20060!",
                passwordConfirmation = "whm20060!"
            };
            await _userService.RegisterUserAsync(input);
        }
    }
}
