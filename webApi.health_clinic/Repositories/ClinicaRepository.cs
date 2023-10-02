using webApi.health_clinic.Contexts;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;

namespace webApi.health_clinic.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ClinicaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Clinica clinicaUpdt)
        {
            Clinica clinicaBuscada = _healthClinicContext.Clinica.Find(id)!;

            if (clinicaBuscada != null)
            {
                clinicaBuscada.NomeFantasia = clinicaUpdt.NomeFantasia;
                clinicaBuscada.RazaoSocial = clinicaUpdt.RazaoSocial;
                clinicaBuscada.CNPJ = clinicaUpdt.CNPJ;
                clinicaBuscada.Endereco = clinicaUpdt.Endereco;
                clinicaBuscada.HorarioFuncionamento = clinicaUpdt.HorarioFuncionamento;
            }

            _healthClinicContext.Clinica.Update(clinicaBuscada!);

            _healthClinicContext.SaveChanges();
        }

        public Clinica BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Clinica clinicaCrt)
        {
            _healthClinicContext.Clinica.Add(clinicaCrt);

            _healthClinicContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                Clinica clinicaDlt = _healthClinicContext.Clinica.FirstOrDefault(u => u.IdClinica == id)!;

                _healthClinicContext.Clinica.Remove(clinicaDlt);

                _healthClinicContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Clinica> Listar()
        {
            return _healthClinicContext.Clinica.ToList();
        }
    }
}
