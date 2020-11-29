using System;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DynamicStackLayoutSize
{
    public class App : Application
    {
        public App() => MainPage = new MyPage();
    }

    class MyPage : ContentPage
    {
        readonly StackLayout _adjustableStackLayout;

        public MyPage()
        {
            Content = new StackLayout
            {
                BackgroundColor = Color.Red,
                Children =
                {
                    new StackLayout
                    {
                        BackgroundColor = Color.Green,
                        Children =
                        {
                            new Label { Text = "Hello" },
                            new Label { Text = "World" }
                        }
                    }.Center().Assign(out _adjustableStackLayout),

                    new Button { Text = "Resize" }.Invoke(resizeButton => resizeButton.Clicked += HandleResizeButtonClicked)
                }
            }.Center();
        }

        void HandleResizeButtonClicked(object sender, EventArgs e)
        {
            if (_adjustableStackLayout.HeightRequest == 196)
                ResizeStackLayout(-1);
            else
                ResizeStackLayout(196);
        }

        void ResizeStackLayout(double heightRequest) => MainThread.BeginInvokeOnMainThread(() => _adjustableStackLayout.HeightRequest = heightRequest);
    }
}
