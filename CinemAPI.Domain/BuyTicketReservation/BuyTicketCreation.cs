﻿using CinemAPI.Data;
using CinemAPI.Domain.Constants;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Domain.Contracts.Models.TicketModels;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketReservation
{
    public class BuyTicketCreation : IBuyTicket
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IReservationRepository reservationRepository;

        public BuyTicketCreation(ITicketRepository ticketRepository, IReservationRepository reservationRepository)
        {
            this.ticketRepository = ticketRepository;
            this.reservationRepository = reservationRepository;
        }

        public async Task<NewTicketSummary> Buy(int id)
        {
            IReservation reservation = await this.reservationRepository.GetById(id);

            Ticket ticket = new Ticket(
                reservation.ProjectionStartDate, 
                reservation.MovieName, 
                reservation.CinemaName,
                reservation.RoomNumber, 
                reservation.Row, 
                reservation.Column, 
                reservation.ProjectionId
                );

            await this.reservationRepository.RemoveReservation(reservation.Id);

            await this.ticketRepository.Insert(ticket);

            return new NewTicketSummary(true, StringConstants.TicketCreated);
        }
    }
}
