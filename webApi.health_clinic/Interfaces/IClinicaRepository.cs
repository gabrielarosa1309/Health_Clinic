using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinicaCrt);
        void Delete(Guid id);
        List<Clinica> Listar();
        Clinica BuscarPorId(Guid id);
        void Atualizar(Guid id, Clinica clinicaUpdt);
    }
}
