using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using sgc_mobile_app.Model;

using Newtonsoft.Json;
using System.Net.Http;

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
            Usuario usuario = new Usuario();
            long cpf = -1;
            long.TryParse(txtCPF.Text, out cpf);
            usuario.CPF = cpf;
            usuario.Senha = txtSenha.Text;

            string URI = "http://localhost:44322/api/usuarios/autenticar";

            Usuario usuarioAutenticado = null;

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        
                        var serializedUsuario = JsonConvert.SerializeObject(usuario);
                        var content = new StringContent(serializedUsuario, Encoding.UTF8, "application/json");
                        var result = await client.PostAsync(URI, content);
                        usuarioAutenticado = JsonConvert.DeserializeObject<Usuario>(await result.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        await DisplayAlert("Erro", "Usuário não autenticado!", "OK");
                    }
                }
            }

            if (usuarioAutenticado != null)
            {
                await Navigation.PushAsync(new MainPage(usuarioAutenticado));
             }
            else
            {
                await DisplayAlert("Erro", "Usuário não autenticado!", "OK");
            }
            
        }
    }
}