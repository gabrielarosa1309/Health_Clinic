using Microsoft.AspNetCore.Http.HttpResults;
using webApi.health_clinic.Contexts;
using webApi.health_clinic.Domains;
using webApi.health_clinic.Interfaces;

namespace webApi.health_clinic.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public TiposUsuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Atualizar(Guid id, TiposUsuario tipoUsuarioUpdt)
        {
            TiposUsuario tipoUsuarioBuscado = _healthClinicContext.TipoUsuario.Find(id)!;

            if (tipoUsuarioBuscado != null) 
            { 
                tipoUsuarioBuscado.Titulo = tipoUsuarioUpdt.Titulo;
            }

            _healthClinicContext.TipoUsuario.Update(tipoUsuarioBuscado!);

            _healthClinicContext.SaveChanges();
        }

        public void Cadastrar(TiposUsuario tipoUsuarioCrt)
        {
            _healthClinicContext.TipoUsuario.Add(tipoUsuarioCrt);

            _healthClinicContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
           try
            {
                TiposUsuario tiposUsuarioDlt = _healthClinicContext.TipoUsuario.FirstOrDefault(u => u.IdTipoUsuario == id)!;

                _healthClinicContext.TipoUsuario.Remove(tiposUsuarioDlt);

                _healthClinicContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<TiposUsuario> Listar()
        {
            return _healthClinicContext.TipoUsuario.ToList();
        }
    }
}
