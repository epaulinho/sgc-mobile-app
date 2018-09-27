using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sgc_mobile_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Autenticar : ContentPage
    {
        public Autenticar()
        {
            InitializeComponent();
            
        }

        private async void btnAutenticar_Clicked(object sender, EventArgs e)
        {
            if(txtCPF.Text.Length>0)
            {
                await Navigation.PushAsync(new MainPage());
             }
            else
            {
                await DisplayAlert("Erro", "Usuário não autenticado!", "OK");
            }
            
        }
    }
}