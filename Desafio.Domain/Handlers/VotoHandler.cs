using Desafio.Domain.Commands.Inputs.Voto;
using Desafio.Domain.Commands.Outputs;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using System;

namespace Desafio.Domain.Handlers
{
    public class VotoHandler : ICommandHandler<AdicionarVotoCommand>, ICommandHandler<ExcluirVotoCommand>
    {
        private readonly IVotoRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IFilmeRepository _filmeRepository;

        public VotoHandler(IVotoRepository repository, IUsuarioRepository usuarioRepository, IFilmeRepository filmeRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _filmeRepository = filmeRepository;
        }

        public ICommandResult Handle(AdicionarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotoCommandResult(false, "Por favor corrija as inconsistências", command.Notifications);
                if (!_usuarioRepository.CheckId(command.IdUsuario))
                    return new VotoCommandResult(false, "Este usuário não existe", new { });
                if (!_filmeRepository.CheckId(command.IdFilme))
                    return new VotoCommandResult(false, "Este filme não existe", new { });

                long id = 0;
                Voto voto = new Voto(id, command.IdUsuario, command.IdFilme);
                id = _repository.Inserir(voto);
                voto.SetId(id);
                return new VotoCommandResult(true, "Voto computado com sucesso", voto);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(ExcluirVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotoCommandResult(false, "Por favor corrija as inconsistências", command.Notifications);
                if (!_repository.CheckId(command.Id))
                    return new VotoCommandResult(false, "Este voto não existe", new { });
                _repository.Remover(command.Id);
                return new VotoCommandResult(true, "Voto excluído com sucesso", new { });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
