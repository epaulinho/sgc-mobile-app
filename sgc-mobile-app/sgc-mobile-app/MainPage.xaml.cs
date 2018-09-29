using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using sgc_mobile_app.Model;

namespace sgc_mobile_app
{
    public partial class MainPage : ContentPage
    {
        //Objeto do Usuario Autenticado
        private Usuario usuarioAutenticado;

        //Contrutor da Classe
        public MainPage(Usuario usuario)
        {
            InitializeComponent();
            //Atribui Usuario para o objeto da classe
            usuarioAutenticado = usuario;
            //Escreve o nome do usuário na tela principal
            lblCumprimento.Text = string.Format("Olá {0}", usuario.Nome);
        }
    }
}
