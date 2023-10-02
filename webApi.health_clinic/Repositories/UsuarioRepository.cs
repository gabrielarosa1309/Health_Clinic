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
            Usuario usuarioBuscado = _healthClinicContext.Usuario.Find(id)!;
            if (usuarioBuscado != null)
            {
                usuarioBuscado.NomeUsuario = usuarioUpdt.NomeUsuario;
                usuarioBuscado.Email = usuarioUpdt.Email;
                usuarioBuscado.Senha = usuarioUpdt.Senha;
            }
            _healthClinicContext.Usuario.Update(usuarioBuscado!);

            _healthClinicContext.SaveChanges();
        }

            public Usuario BuscarPorCPFeSenha(string CPF, string senha)
            {
                try
                {
                    Usuario usuarioBuscado = _healthClinicContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        NomeUsuario = u.NomeUsuario,
                        CPF = u.CPF,
                        Email = u.Email,
                        Senha = u.Senha,
                        TiposUsuario = new TiposUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TiposUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.CPF == CPF)!;

                    if (usuarioBuscado != null)
                    {
                        bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                        if (confere)
                        {
                            return usuarioBuscado;
                        }
                    }
                    return null!;
                }
                catch
                {
                    throw;
                }
            }

            public Usuario BuscarPorId(Guid id)
            {
                return _healthClinicContext.Usuario.FirstOrDefault(u => u.IdUsuario == id)!;
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
