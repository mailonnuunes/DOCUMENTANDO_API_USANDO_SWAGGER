using APIAlura.Entity;

namespace APIAlura.Services
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);

    }
}
