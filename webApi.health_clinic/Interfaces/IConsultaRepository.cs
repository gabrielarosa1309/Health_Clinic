using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consultaCrt);
        void Delete(Guid id);
        public List<Consulta> ListarDeMedico(Guid idMedico);
        public List<Consulta> ListarDePaciente(Guid idPaciente);
        public List<Consulta> Listar();
        Consulta BuscarPorId(Guid id);
        void Atualizar(Guid id, Consulta consultaUpdt);
    }
}
