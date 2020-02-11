﻿using CinemAPI.Data;
using CinemAPI.Domain.Constants;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Domain.Contracts.Models.TicketModels;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketReservation
{
    public class BuyTicketReservationExpiredValidation : IBuyTicket
    {
        private readonly IProjectionRepository projRepo;
        private readonly IBuyTicket buyTicket;
        private readonly IReservationRepository reservationRepository;

        public BuyTicketReservationExpiredValidation(IProjectionRepository projRepo, IBuyTicket buyTicket, IReservationRepository reservationRepository)
        {
            this.projRepo = projRepo;
            this.buyTicket = buyTicket;
            this.reservationRepository = reservationRepository;
        }

        public async Task<NewTicketSummary> Buy(int id)
        {
            IReservation reservation = await this.reservationRepository.GetById(id);
            DateTime projectionStartdate = await this.projRepo.GetProjectionStartDate(reservation.ProjectionId);

            //TODO: check if time is correctly set.
            if (DateTime.Now.AddMinutes(10) >= projectionStartdate)
            {
                int count = await this.reservationRepository.RemoveAllReservations(reservation.ProjectionId);
                await this.projRepo.IncreaseAvailableSeats(reservation.ProjectionId, count);

                return new NewTicketSummary(false, StringConstants.ReservationExpired);
            }

            return await buyTicket.Buy(id);
        }
    }
}
