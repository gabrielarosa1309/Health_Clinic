using webApi.health_clinic.Contexts;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;

namespace webApi.health_clinic.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public EspecialidadeRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Especialidade especialidadeUpdt)
        {
            Especialidade especialidadeBuscada = _healthClinicContext.Especialidade.Find(id)!;

            if (especialidadeBuscada != null)
            {
                especialidadeBuscada.TituloEspecialidade = especialidadeUpdt.TituloEspecialidade;
            }

            _healthClinicContext.Especialidade.Update(especialidadeBuscada!);

            _healthClinicContext.SaveChanges();
        }

        public Especialidade BuscarPorId(Guid id)
        {
            return _healthClinicContext.Especialidade.FirstOrDefault(u => u.IdEspecialidade == id)!;
        }

        public void Cadastrar(Especialidade especialidadeCrt)
        {
            _healthClinicContext.Especialidade.Add(especialidadeCrt);

            _healthClinicContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                Especialidade especialidadeDlt = _healthClinicContext.Especialidade.FirstOrDefault(u => u.IdEspecialidade == id)!;

                _healthClinicContext.Especialidade.Remove(especialidadeDlt);

                _healthClinicContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Especialidade> Listar()
        {
            return _healthClinicContext.Especialidade.ToList();
        }
    }
}
