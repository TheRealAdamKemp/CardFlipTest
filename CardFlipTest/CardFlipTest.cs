using System;

using Xamarin.Forms;

namespace CardFlipTest
{
    public class App : Application
    {
        public App()
        {
            var flipView = new FlipCardView {
                Top = new Label { Text = "Top" },
                Bottom = new Label { Text = "Bottom" },
            };
            var button = new Button { Text = "Flip" };
            button.Clicked += (s, e) => flipView.Flip(animate: true);

            MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        flipView,
                        button
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

