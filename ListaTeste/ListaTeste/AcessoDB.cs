using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using System.IO;
using SQLite;

namespace ListaTeste
{
    public class AcessoDB: IDisposable
    {
        private SQLiteConnection conexaoSQLite;
        private static AcessoDB instanciaDB;

    public static AcessoDB Instancia()
        {

            if (instanciaDB == null)
                instanciaDB = new AcessoDB();
            return instanciaDB;

        }

        
        public AcessoDB()
        {
            var config = DependencyService.Get<IConfig>();
            conexaoSQLite = new SQLiteConnection(Path.Combine(config.DiretorioSQLite, "CadastroLista2.db3"));
            conexaoSQLite.CreateTable<ListaBD>();

        }

        public void Dispose()
        {
            conexaoSQLite.Dispose();
        }

        public void InserirLista(ListaBD listabd)
        {
            conexaoSQLite.Insert(listabd);
        }
        public List<ListaBD> GetListaBD()
        {
            return conexaoSQLite.Table<ListaBD>().OrderBy(c => c.IdLista).ToList();
        }

        public void ExcluirItemLista(ListaBD listabd)
        {
            conexaoSQLite.Delete(listabd);
        }
        public void AtualizarItemLista(ListaBD listabd)
        {
            conexaoSQLite.Update(listabd);
        }
        public ListaBD GetItemListaDB(int id)
        {
            return conexaoSQLite.Table<ListaBD>().FirstOrDefault(c => c.IdLista == id);
        }

    }
}