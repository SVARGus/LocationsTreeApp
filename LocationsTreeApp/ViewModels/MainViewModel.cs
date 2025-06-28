using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LocationsTreeApp.Models;
using LocationsTreeApp.Services;

namespace LocationsTreeApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        readonly ILocationService _locationService;

        public ObservableCollection<LocationNode> Locations { get; } = new ObservableCollection<LocationNode>();

        public ICommand LoadCommand { get; }

        public MainViewModel(ILocationService locationService)
        {
            _locationService = locationService;
            LoadCommand = new Command(async () => await LoadAsync());
        }

        async Task LoadAsync()
        {
            var tree = await _locationService.GetTreeAsync();
            Locations.Clear();
            foreach (var item in tree)
            {
                Locations.Add(item);
            }
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string p = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }
}
