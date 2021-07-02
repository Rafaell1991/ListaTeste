using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaTeste
{
    public partial class MainPage : ContentPage
    {        
        List<string> lista = new List<string>();
        
        public MainPage()
        {
            InitializeComponent();
            Mercado.ItemsSource = AcessoDB.Instancia().GetListaBD();
        }       

        private void Mercado_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            entrada.Text = e.SelectedItem.ToString().Substring(e.SelectedItem.ToString().IndexOf(" ") + 1);// e.SelectedItem.ToString().Split()[1];
        }

        private void Button_Salvar(object sender, EventArgs e)
        {
            var listabd = new ListaBD();

            listabd.IdLista = -1;
            listabd.NomeLista = entrada.Text;            

            AcessoDB.Instancia().InserirLista(listabd);
            Mercado.ItemsSource = AcessoDB.Instancia().GetListaBD();         
            
            /*
            using (var dados = new AcessoDB())
            {
                dados.InserirLista(listabd);
                Mercado.ItemsSource = dados.GetListaBD();
            }
            */
        }

        private void Button_ExcluirItem(object sender, EventArgs e)
        {
            var listabd = new ListaBD();

            listabd.IdLista = Int16.Parse(Mercado.SelectedItem.ToString().Split()[0]);          


            AcessoDB.Instancia().ExcluirItemLista(listabd);
            Mercado.ItemsSource = AcessoDB.Instancia().GetListaBD();

        }
        private void Button_AtualizarItem(object sender, EventArgs e)
        {
            var listabd = new ListaBD();

            listabd.IdLista = Int16.Parse(Mercado.SelectedItem.ToString().Split()[0]);
            listabd.NomeLista = entrada.Text;

            AcessoDB.Instancia().AtualizarItemLista(listabd);
            Mercado.ItemsSource = AcessoDB.Instancia().GetListaBD();

        }
    }
}
