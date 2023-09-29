using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuarioCrt);
        void Delete(Guid id);
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
        Usuario BuscarPorCPFeSenha(string CPF, string senha);
        void Atualizar(Guid id, Usuario usuarioUpdt);
    }
}
