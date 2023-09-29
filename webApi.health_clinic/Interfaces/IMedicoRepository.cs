using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medicoCrt);
        void Delete(Guid id);
        List<Medico> Listar();
        Medico BuscarPorId(Guid id);
        Medico BuscarPorCPFeSenha(string CPF, string senha);
        void Atualizar(Guid id, Medico medicoUpdt);
    }
}
