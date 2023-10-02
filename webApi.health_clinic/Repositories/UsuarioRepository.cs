using webApi.health_clinic.Contexts;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;
using webApi.health_clinic.Utils;

namespace webApi.health_clinic.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public UsuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Usuario usuarioUpdt)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorCPFeSenha(string CPF, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuarioCrt)
        {
            try
            {
                usuarioCrt.Senha = Criptografia.GerarHash(usuarioCrt.Senha!);

                _healthClinicContext.Usuario.Add(usuarioCrt);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                Usuario usuarioDlt = _healthClinicContext.Usuario.FirstOrDefault(u => u.IdUsuario == id)!;

                _healthClinicContext.Usuario.Remove(usuarioDlt);

                _healthClinicContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Usuario> Listar()
        {
            return _healthClinicContext.Usuario.ToList();
        }
    }
}
