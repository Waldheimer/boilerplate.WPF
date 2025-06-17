using Apmt_WPF.Exceptions;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Apmt_WPF.Navigation;

public class TargetNavigationService<TViewModel> where TViewModel : ObservableRecipient
{

    private readonly MultiNavigationManager _manager;
    private readonly Func<TViewModel> _viewModelFactory;

    public TargetNavigationService(MultiNavigationManager manager, Func<TViewModel> viewModelFactory)
    {
        _manager = manager;
        _viewModelFactory = viewModelFactory;
    }

    public void NavigateTo(string targetContentControl)
    {
        try
        {
            _manager.CurrentViewModels[targetContentControl] = _viewModelFactory.Invoke();
        }
        catch
        {
            throw new UnregisteredNavigationTargetAreaException(targetContentControl);
        }
    }
}
