using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageFlyout : ContentPage
    {
        public ListView ListView;

        public MainPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MainPageFlyoutViewModel : INotifyPropertyChanged
        {
            public string ApplicationName { get; set; } = "Laboratorio 4" + $" Xamarin {typeof(Page).Assembly.GetName().Version}";

            public ObservableCollection<MainPageFlyoutMenuItem> MenuItems { get; set; }

            public MainPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainPageFlyoutMenuItem>(new[]
                {
                    new MainPageFlyoutMenuItem { Id = 0, Title = "Hello world", TargetType = typeof(HelloWorldPage)},
                    new MainPageFlyoutMenuItem { Id = 1, Title = "Xamarin Controls", TargetType = typeof(ControlsPage) },
                    new MainPageFlyoutMenuItem { Id = 2, Title = "My Todo Do", TargetType = typeof(ToDosPage)},
                    new MainPageFlyoutMenuItem { Id = 3, Title = "Blogs", TargetType = typeof(BlogsPage)},
                });
            }

            #region INotifyPropertyChanged Implementation

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion INotifyPropertyChanged Implementation
        }
    }
}