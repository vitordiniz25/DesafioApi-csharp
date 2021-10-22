using Desafio.Domain.Commands.Inputs.Filme;
using Desafio.Domain.Commands.Outputs;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using System;

namespace Desafio.Domain.Handlers
{
    public class FilmeHandler : ICommandHandler<AdicionarFilmeCommand>, ICommandHandler<AtualizarFilmeCommand>, 
            ICommandHandler<RemoverFilmeCommand>
    {
        private readonly IFilmeRepository _repository;

        public FilmeHandler(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Por favor corrija as inconsistências", command.Notifications);
                long id = 0;
                Filme filme = new Filme(id, command.Titulo, command.Diretor);
                id = _repository.Inserir(filme);
                filme.SetId(id);
                return new FilmeCommandResult(true, "Filme adicionado com sucesso!", filme);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AtualizarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Por favor corrija as inconsistências", command.Notifications);
                if (!_repository.CheckId(command.Id))
                    return new FilmeCommandResult(false, "Esse filme não existe!", new { });
                Filme filme = new Filme(command.Id, command.Titulo, command.Diretor);
                _repository.Atualizar(filme);
                return new FilmeCommandResult(true, "Filme atualizado com sucesso!", filme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(RemoverFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Por favor corrija as inconsistências", command.Notifications);
                if (!_repository.CheckId(command.Id))
                    return new FilmeCommandResult(false, "Esse filme não existe!", new { });
                
                _repository.Remover(command.Id);
                return new FilmeCommandResult(true, "Filme removido com sucesso!", new { });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
