using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Repositories;
using GerenciadorRestaurante.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper _mapper;

        public ReservaService(IReservaRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _mapper = mapper;
        }

        public Task<ReservaViewModel> AtualizarReserva(int id, ReservaInputModel reservaInputModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ReservaViewModel> CadastrarReserva(ReservaInputModel reservaInputModel)
        {
            var reserva = _mapper.Map<Reserva>(reservaInputModel);

            bool exits = await _reservaRepository.ExistAsync(j => j.MesaId == reservaInputModel.MesaId);

            if (exits) throw new AlreadyExistsException();

            var model = await _reservaRepository.InserirAsync(reserva);

            return _mapper.Map<ReservaViewModel>(model);
        }

        public async Task<ReservaViewModel> ConsultarReservaPorId(int id)
        {
            var reserva = await _reservaRepository.ObterPorIdAsync(id) ?? throw new NotFoundException();

            return _mapper.Map<ReservaViewModel>(reserva);
        }

        public async Task<IEnumerable<ReservaViewModel>> ConsultarTodasAsReservas()
        {
            var reservas = await _reservaRepository.ObterTodosAsync() ?? throw new NotFoundException();

            return _mapper.Map<IEnumerable<ReservaViewModel>>(reservas);
        }

        public async Task<ReservaViewModel> DeletarReserva(int id)
        {
            Reserva? reserva = await _reservaRepository.ObterPorIdAsync(id) ?? throw new NotFoundException();

            await _reservaRepository.ExcluirAsync(reserva.Id);

            return _mapper.Map<ReservaViewModel>(reserva);
        }
    }
}
