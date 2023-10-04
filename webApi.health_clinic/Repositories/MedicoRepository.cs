using webApi.health_clinic.Contexts;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;
using webApi.health_clinic.Utils;

namespace webApi.health_clinic.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public MedicoRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Cadastrar(Medico medicoCrt)
        {
            _healthClinicContext.Medico.Add(medicoCrt);

            _healthClinicContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                Medico medicoDlt = _healthClinicContext.Medico.FirstOrDefault(u => u.IdMedico == id)!;

                _healthClinicContext.Medico.Remove(medicoDlt);

                _healthClinicContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
