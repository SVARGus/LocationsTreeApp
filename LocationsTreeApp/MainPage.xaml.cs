using LocationsTreeApp.ViewModels;

namespace LocationsTreeApp
{
    public partial class MainPage : ContentPage
    {
        readonly MainViewModel _vm;

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
            Loaded += (_, __) => _vm.LoadCommand.Execute(null);
        }
    }
}
