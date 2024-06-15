using ReservaBiblio.Shared;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ReservaBiblio.Client.Providers
{
    public class AutenticacionExtension : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AutenticacionExtension(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }
        public async Task ActualizarEstadoAutenticacion(ProfesoresDTO sesionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;

            if (sesionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sesionUsuario.Nombre),
                    new Claim(ClaimTypes.Sid, sesionUsuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, sesionUsuario.RangoAdministrador),
                }, "JwtAuth"));

                await _sessionStorage.GuardarStorage("sesionUsuario", sesionUsuario);
            }
            else
            {
                claimsPrincipal = _sinInformacion;
                await _sessionStorage.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _sessionStorage.ObtenerStorage<ProfesoresDTO>("sesionUsuario");

            if (sesionUsuario == null) { return await Task.FromResult(new AuthenticationState(_sinInformacion)); }

            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, sesionUsuario.Nombre),
                new Claim(ClaimTypes.Sid, sesionUsuario.Id.ToString()),
                new Claim(ClaimTypes.Role, sesionUsuario.RangoAdministrador),
            }, "JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimPrincipal));
        }
    }
}
