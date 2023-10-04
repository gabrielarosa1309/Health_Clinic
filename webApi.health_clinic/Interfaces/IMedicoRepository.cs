using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medicoCrt);
        void Delete(Guid id);
    }
}
