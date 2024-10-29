using FlashCardApp.Pages;

namespace FlashCardApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new QuizPage());
        }
    }
}
