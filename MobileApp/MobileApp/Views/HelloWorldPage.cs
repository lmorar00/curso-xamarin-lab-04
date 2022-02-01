using Xamarin.Forms;

namespace MobileApp.Views
{
    public class HelloWorldPage : ContentPage
    {
        public HelloWorldPage()
        {
            var label = new Label
            {
                Text = "Hello, World!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };

            var button = new Button { Text = "Click me!" };
            int i = 0;
            button.Clicked += (s, e) =>
            {
                button.Text = "Hello, World! " + i++;
            };

            BackgroundColor = Color.Transparent;

            Content = new StackLayout
            {
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = { label, button }
            };

            Title = "HelloWorldPage";
        }

        public string Username { get; set; } = "Unknown User";
    }
}