using System.Collections.ObjectModel;
using LocationsTreeApp.Models;

namespace LocationsTreeApp.Services
{
    public interface ILocationService
    {
        Task<ObservableCollection<LocationNode>> GetTreeAsync();
    }
}
