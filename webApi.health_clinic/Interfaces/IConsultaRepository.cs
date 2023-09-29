using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consultaCrt);
        void Delete(Guid id);
        List<Consulta> Listar();
        Consulta BuscarPorId(Guid id);
        void Atualizar(Guid id, Consulta consultaUpdt);
    }
}
