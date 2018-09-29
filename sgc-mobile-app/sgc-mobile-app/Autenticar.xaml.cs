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
        //Construtor da classe
        public Autenticar()
        {
            InitializeComponent();
            
        }

        //Metódo para autenticar o usuário
        private async void btnAutenticar_Clicked(object sender, EventArgs e)
        {
            //Cria objeto do usuário
            Usuario usuario = new Usuario();
            //Cria variável CPF do tipo long
            long cpf = -1;
            //Converte o CPF digitado na tela por um objeto tipo long
            long.TryParse(txtCPF.Text, out cpf);

            //Atribui propriedades do Usuario de acordo com os valores da tela
            usuario.CPF = cpf;
            usuario.Senha = txtSenha.Text;

            //Endereço da WEB API para autenticar o usuário
            string URI = "http://sgc-api.azurewebsites.net/api/usuarios/autenticar";

            //Cria objeto de Usuario autenticado
            Usuario usuarioAutenticado = null;

            //Cria objeto para chamar o método da REST API
            using (var client = new HttpClient())
            {
                //Cria JSON do objeto Usuário
                var serializedUsuario = JsonConvert.SerializeObject(usuario);
                //Cria objeto para chamada do metodo da API do tipo JSON
                var content = new StringContent(serializedUsuario, UnicodeEncoding.UTF8, "application/json");
                //Chama método da REST API para autenticar usuário
                var result = client.PostAsync(URI, content).Result;
                //Convert JSON do retorno da REST API para objeto Usuario
                usuarioAutenticado = JsonConvert.DeserializeObject<Usuario>(await result.Content.ReadAsStringAsync());   
            }

            //Verifica se encontrou o usuário
            if (usuarioAutenticado != null)
            {
                //Usuario autenticado. Navega para Página principal
                await Navigation.PushAsync(new MainPage(usuarioAutenticado));
             }
            else
            {
                //Mensagem de erro por nao ter encontrado o usuario
                await DisplayAlert("Erro", "Usuário não autenticado!", "OK");
            }
            
        }
    }
}