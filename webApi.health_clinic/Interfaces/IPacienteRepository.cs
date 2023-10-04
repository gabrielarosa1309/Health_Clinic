using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente pacienteCrt);
        void Delete(Guid id);
    }
}
