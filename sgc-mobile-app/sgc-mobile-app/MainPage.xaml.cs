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
        private Usuario usuarioAutenticado;

        public MainPage(Usuario usuario)
        {
            InitializeComponent();
            usuarioAutenticado = usuario;
            lblCumprimento.Text = string.Format("Olá {0)", usuario.Nome);
        }
    }
}
