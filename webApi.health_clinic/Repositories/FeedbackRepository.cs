using webApi.health_clinic.Contexts;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;
using webApi.health_clinic.Utils;

namespace webApi.health_clinic.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public FeedbackRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Feedback feedbackUpdt)
        {
            Feedback feedbackBuscado = _healthClinicContext.Feedback.Find(id)!;

            if (feedbackBuscado != null)
            {
                feedbackBuscado.FeedbackConsulta = feedbackUpdt.FeedbackConsulta;
            }

            _healthClinicContext.Feedback.Update(feedbackBuscado!);

            _healthClinicContext.SaveChanges();
        }

        public Feedback BuscarPorId(Guid id)
        {
            return _healthClinicContext.Feedback.FirstOrDefault(u => u.IdFeedback == id)!;
        }

        public void Cadastrar(Feedback feedbackCrt)
        {
            _healthClinicContext.Feedback.Add(feedbackCrt);

            _healthClinicContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            try
            {
                Feedback feedbackDlt = _healthClinicContext.Feedback.FirstOrDefault(u => u.IdFeedback == id)!;

                _healthClinicContext.Feedback.Remove(feedbackDlt);

                _healthClinicContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Feedback> Listar()
        {
            return _healthClinicContext.Feedback.ToList();
        }
    }
}
