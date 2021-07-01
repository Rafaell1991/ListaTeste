using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaTeste
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Entrar : ContentPage
    {
        public Entrar()
        {
            InitializeComponent();
        }

        private void Button_Entrar(object sender, EventArgs e)
        {
            if (Usuario.Text == "Rafael" && Senha.Text == "123")
                App.Current.MainPage = new MainPage();
            else
                DisplayAlert("Atenção","Usuário e/ou senha incorretos. Tente novamente", "Entendi");
        }
    }
}