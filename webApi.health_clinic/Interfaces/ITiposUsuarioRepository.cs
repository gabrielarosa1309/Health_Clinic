using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario tipoUsuarioCrt);
        void Delete(Guid id);
        List<TiposUsuario> Listar();
        void Atualizar(Guid id, TiposUsuario tipoUsuarioUpdt);
    }
}
