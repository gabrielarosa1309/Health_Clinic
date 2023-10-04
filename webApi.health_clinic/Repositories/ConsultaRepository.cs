using webApi.health_clinic.Contexts;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;
using webApi.health_clinic.Utils;

namespace webApi.health_clinic.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ConsultaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Consulta consultaUpdt)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta.Find(id)!;

            if (consultaBuscada != null)
            {
                consultaBuscada.DatetimeConsulta = consultaUpdt.DatetimeConsulta;
                consultaBuscada.DescricaoConsulta = consultaUpdt.DescricaoConsulta;
                consultaBuscada.Confirmacao = consultaUpdt.Confirmacao;
            }

            _healthClinicContext.Consulta.Update(consultaBuscada!);

            _healthClinicContext.SaveChanges();
        }

        public Consulta BuscarPorId(Guid id)
        {
            return _healthClinicContext.Consulta.FirstOrDefault(u => u.IdConsulta == id)!;
        }

        public void Cadastrar(Consulta consultaCrt)
        {
            _healthClinicContext.Consulta.Add(consultaCrt);

            _healthClinicContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                Consulta consultaDlt = _healthClinicContext.Consulta.FirstOrDefault(u => u.IdConsulta == id)!;

                _healthClinicContext.Consulta.Remove(consultaDlt);

                _healthClinicContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Consulta> ListarDeMedico(Guid idMedico)
        {
            return _healthClinicContext.Consulta.Where(u => u.IdMedico == idMedico).ToList();
        }

        public List<Consulta> ListarDePaciente(Guid idPaciente)
        {
            return _healthClinicContext.Consulta.Where(u => u.IdPaciente == idPaciente).ToList();
        }

        public List<Consulta> Listar()
        {
            return _healthClinicContext.Consulta.ToList();
        }
    }
}
