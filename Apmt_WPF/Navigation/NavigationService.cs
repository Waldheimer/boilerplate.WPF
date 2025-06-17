using CommunityToolkit.Mvvm.ComponentModel;

namespace Apmt_WPF.Navigation;

//  *********************************************************************************
//  ***** NavigationService-Class for Navigating between ViewModels *****************
//  ***** in a single Navigation-Context                            *****************
//  *********************************************************************************
public class NavigationService<TViewModel> where TViewModel : ObservableRecipient
{
    //  **********************
    //  NavigationManager Instace and FactoryMethod required for Navigation
    //  **********************
    private readonly NavigationManager _navigationManager;
    private readonly Func<TViewModel> _viewModelFactory;

    //  **********************
    //  Constructor for NavigationManager and ViewModelFactory
    //  **********************
    public NavigationService(NavigationManager navigationManager, Func<TViewModel> viewModelFactory)
    {
        _navigationManager = navigationManager;
        _viewModelFactory = viewModelFactory;
    }

    //  **********************
    //  Navigate to the Instance of TViewModel by setting the CurrentViewModel-Property
    //  of the NavigationManager to the result of the ViewModelFactory-Function
    //  **********************
    public void Navigate()
    {
        var cvm = _viewModelFactory.Invoke();
        _navigationManager.CurrentViewModel = cvm;
    }
}
