using webApi.health_clinic.Domains;

namespace webApi.health_clinic.Interfaces
{
    public interface IFeedbackRepository
    {
        void Cadastrar(Feedback feedbackCrt);
        void Delete(Guid id);
        List<Feedback> Listar();
        Feedback BuscarPorId(Guid id);
        void Atualizar(Guid id, Feedback feedbackUpdt);
    }
}
