using FluentAssertions;
using SistemaMedico.Repository;
using SistemaMedicoV3.Models;
using SistemaMedicoV3.Repository;
using SistemaMedicoV3.Services;
using System;
using TechTalk.SpecFlow;

namespace Tests.StepsDefinitions
{
    [Binding]
    public class IniciarSesionStepDefinitions
    {
        private AutenticarService _authService;
        private UsuariosRepository _repositorio;
        private MedicosRepository _Medicos;
        private bool _resultadoInicioSesion = false;
        public IniciarSesionStepDefinitions()
        {
            _repositorio = new UsuariosRepository();
            _Medicos = new MedicosRepository();
            _authService = new AutenticarService(_repositorio, _Medicos);
        }
        [Given(@"existe un usuario con email ""([^""]*)"" y contraseña ""([^""]*)""")]
        public void GivenExisteUnUsuarioConEmailYContrasena(string email, string password)
        {
            var usuario = new Usuario (email, BCrypt.Net.BCrypt.HashPassword(password));

            _repositorio.ObtenerUsuarios().Add(usuario);
        }

        [When(@"el usuario intenta iniciar sesión con email ""([^""]*)"" y contraseña ""([^""]*)""")]
        public void WhenElUsuarioIntentaIniciarSesionConEmailYContrasena(string email, string password)
        {
            if(_authService.IniciarSesion(email, password) != null)
            {
                _resultadoInicioSesion = true;
            }
            
        }

        [Then(@"el inicio de sesión debería ser con exitoso")]
        public void ThenElInicioDeSesionDeberiaSerConExitoso()
        {
            _resultadoInicioSesion.Should().BeTrue();
        }

        [When(@"el usuario ingresa el email ""([^""]*)"" y una contraseña incorrecta ""([^""]*)""")]
        public void WhenElUsuarioIngresaElEmailYUnaContrasenaIncorrecta(string email, string passwordIncorrecta)
        {
            if (_authService.IniciarSesion(email, passwordIncorrecta) != null)
            {
                _resultadoInicioSesion = true;
            }
        }

        [Then(@"el inicio de sesión debería ser sin exitoso")]
        public void ThenElInicioDeSesionDeberiaSerSinExitoso()
        {
            _resultadoInicioSesion.Should().BeFalse();
        }

        [Given(@"no existe un usuario con email ""([^""]*)""")]
        public void GivenNoExisteUnUsuarioConEmail(string email)
        {
            Usuario? usuario = _authService.BuscarPorEmail(email);
            //usuario.Should().BeNull;
        }

        [When(@"el usuario intenta iniciar sesión con el email inexistente ""([^""]*)"" y la contraseña ""([^""]*)""")]
        public void WhenElUsuarioIntentaIniciarSesionConElEmailInexistenteYLaContrasena(string emailInexistente, string passwordInexistente)
        {
            if (_authService.IniciarSesion(emailInexistente, passwordInexistente) != null)
            {
                _resultadoInicioSesion = true;
            }
        }

        [Then(@"el inicio de sesión debería fallar por usuario inexistente")]
        public void ThenElInicioDeSesionDeberiaFallarPorUsuarioInexistente()
        {
            _resultadoInicioSesion.Should().BeFalse();
        }
    }
}
