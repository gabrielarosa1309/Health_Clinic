using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidadeCrt);
        void Delete(Guid id);
        List<Especialidade> Listar();
        Especialidade BuscarPorId(Guid id);
        void Atualizar(Guid id, Especialidade especialidadeUpdt);
    }
}
