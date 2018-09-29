using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace sgc_mobile_app
{
    public partial class App : Application
    {
        //Construtor da Classe
        public App()
        {
            InitializeComponent();
            //Inicia a aplicação com a página Autenticar
            MainPage = new NavigationPage(new Autenticar());
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
