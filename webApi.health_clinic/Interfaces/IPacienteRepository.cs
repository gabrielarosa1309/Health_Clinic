using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente pacienteCrt);
        void Delete(Guid id);
        List<Paciente> Listar();
        Paciente BuscarPorId(Guid id);
        Paciente BuscarPorCPFeSenha(string CPF, string senha);
        void Atualizar(Guid id, Paciente pacienteUpdt);
    }
}
