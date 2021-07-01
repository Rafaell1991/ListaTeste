using SQLite.Net.Interop;

namespace ListaTeste
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }
        ISQLitePlatform Plataforma { get; }
    }
}