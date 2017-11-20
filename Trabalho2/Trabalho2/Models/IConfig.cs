using SQLite.Net.Interop;

namespace Trabalho2.Models
{
    public interface IConfig
    {
        string DiretorioDB { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
