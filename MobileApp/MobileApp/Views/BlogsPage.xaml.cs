using MobileApp.Models;
using MobileApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogsPage : ContentPage, INotifyPropertyChanged
    {
        //public System.Lazy<BloggingDBContext> DbContext { get; set; }
        //    = new System.Lazy<BloggingDBContext>(() => new BloggingDBContext());

        public ObservableCollection<string> Items { get; set; }

        public BlogsPage()
        {
            InitializeComponent();

            //Items = new ObservableCollection<string>(DbContext.Value.Blogs.Select(blog => blog.Url));

            //ItemsView.ItemsSource = Items;
        }

        protected override async void OnAppearing()
        {
            ItemsView.SelectedItem = null;

            using (BloggingDBContext blogContext = new BloggingDBContext())
            {
                await InsertStartData(blogContext);

                System.Collections.Generic.List<Blog> theBlogs = blogContext.Blogs.ToList();

                ItemsView.ItemsSource = theBlogs;
            }
        }

        private async Task InsertStartData(BloggingDBContext context)
        {
            int blogCount = context.Blogs.Count();

            if (blogCount == 0)
            {
                _ = await context.AddAsync(new Blog { Url = "https://devblogs.microsoft.com/xamarin" });
                _ = await context.AddAsync(new Blog { Url = "https://aka.ms/appsonazureblog" });

                _ = await context.SaveChangesAsync();
            }
        }
    }
}