using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LocationsTreeApp.Models
{
    public class LocationNode : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ObservableCollection<LocationNode> Children { get; } = new ObservableCollection<LocationNode>();

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { _isExpanded = value; OnPropertyChanged(); }
        }

        public ICommand ToggleCommand => new Command(() => IsExpanded = !IsExpanded);

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
