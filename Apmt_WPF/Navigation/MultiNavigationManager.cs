using CommunityToolkit.Mvvm.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace Apmt_WPF.Navigation;

public class MultiNavigationManager
{
    private List<string> navigationAreas;
    private Dictionary<string, ObservableRecipient> _currentViewModels;

    public List<string> NavigationAreas
    {
        get => navigationAreas;
        set => navigationAreas = value; 
    }
    public Dictionary<string, ObservableRecipient> CurrentViewModels
    {
        get => _currentViewModels;
        set
        {
            _currentViewModels = value;
            OnAnyViewModelChanged();
        }
    }

    public static void RegisterForNavigation(string navigationName)
    {

    }

    public event Action? AnyViewModelChanged;

    public MultiNavigationManager()
    {
        this.navigationAreas = new List<string>();
        this._currentViewModels = new Dictionary<string, ObservableRecipient>();
    }

    private void OnAnyViewModelChanged()
    {
        AnyViewModelChanged?.Invoke();
    }

    
}
