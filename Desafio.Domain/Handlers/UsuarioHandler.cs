using Desafio.Domain.Commands.Inputs.Usuario;
using Desafio.Domain.Commands.Outputs;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using System;

namespace Desafio.Domain.Handlers
{
    public class UsuarioHandler : ICommandHandler<AdicionarUsuarioCommand>, ICommandHandler<AtualizarUsuarioCommand>,
        ICommandHandler<RemoverUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor corrija as inconsistências", command.Notifications);
                long id = 0;
                Usuario usuario = new Usuario(id, command.Nome, command.Login, command.Senha);
                id = _repository.Inserir(usuario);
                usuario.SetId(id);
                return new UsuarioCommandResult(true, "Usuário Cadastrado com sucesso", usuario);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AtualizarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor corrija as inconsistências", command.Notifications);
                if (!_repository.CheckId(command.Id))
                    return new UsuarioCommandResult(false, "Esse usuário não existe", new { });
                Usuario usuario = new Usuario(command.Id, command.Nome, command.Login, command.Senha);
                _repository.Atualizar(usuario);
                return new UsuarioCommandResult(true, "Usuário atualizado com sucesso", usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(RemoverUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor corrija as inconsistências", command.Notifications);
                if (!_repository.CheckId(command.Id))
                    return new UsuarioCommandResult(false, "Esse usuário não existe", new { });

                _repository.Remover(command.Id);
                return new UsuarioCommandResult(true, "Usuário excluído com sucesso", new { });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
