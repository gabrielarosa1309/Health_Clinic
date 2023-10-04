using webApi.health_clinic.Contexts;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;

namespace webApi.health_clinic.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public PacienteRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Cadastrar(Paciente pacienteCrt)
        {
            _healthClinicContext.Paciente.Add(pacienteCrt);

            _healthClinicContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                Paciente pacienteDlt = _healthClinicContext.Paciente.FirstOrDefault(u => u.IdPaciente == id)!;

                _healthClinicContext.Paciente.Remove(pacienteDlt);

                _healthClinicContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}