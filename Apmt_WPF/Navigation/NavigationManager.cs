using CommunityToolkit.Mvvm.ComponentModel;

namespace Apmt_WPF.Navigation;

//  *********************************************************************************
//  ***** NavigationManager-Class for managing the current State    *****************
//  ***** of the Navigation in a single NavigationContext           *****************
//  *********************************************************************************
public class NavigationManager
{
    //  **********************
    //  Property for the ViewModel that is the current Navigation-Target
    //  **********************
    private ObservableRecipient? _currentViewModel;
    public ObservableRecipient? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public NavigationManager() { }

    //  **********************
    //  CurrentViewModelChanged-Event for ViewModels executing the Navigation to subscribe to
    //  **********************
    public event Action? CurrentViewModelChanged;

    //  **********************
    //  Raise the CurrentViewModelChanged-Event when the CurrentViewModel changes
    //  **********************
    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}