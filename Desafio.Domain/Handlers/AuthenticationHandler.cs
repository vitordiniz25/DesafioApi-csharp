using Desafio.Domain.Commands.Inputs.Authentication;
using Desafio.Domain.Commands.Outputs;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using Desafio.Infra.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio.Domain.Handlers
{
    public class AuthenticationHandler : ICommandHandler<AuthenticationCommand>
    {
        private readonly IUsuarioRepository _repository;
        private readonly AppSettings _settings;

        public AuthenticationHandler(IUsuarioRepository repository, AppSettings settings)
        {
            _repository = repository;
            _settings = settings;
        }

        public ICommandResult Handle(AuthenticationCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AuthenticationCommandResult(false, "Por favor corrija as inconsistências.", command.Notifications);

                if (!_repository.Autenticar(command.Login, command.Senha))
                    return new AuthenticationCommandResult(false, "Login ou senha inválido.", new { });

                return new AuthenticationCommandResult(true, "Token Gerado", GerarToken(command.Login));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private object GerarToken(string login)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, login));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _settings.Issuer,
                Audience = _settings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_settings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);

            return new
            {
                AcessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_settings.Expiration).TotalSeconds
            };
        }
    }
}
