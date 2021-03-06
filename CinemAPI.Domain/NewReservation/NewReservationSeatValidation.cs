﻿using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Reservation;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationSeatValidation : INewReservation
    {
        private readonly INewReservation newReservation;
        private readonly IRoomRepository roomRepo;
        private readonly IProjectionRepository projRepo;

        public NewReservationSeatValidation(INewReservation newReservation, IRoomRepository roomRepo, IProjectionRepository projRepo)
        {
            this.newReservation = newReservation;
            this.roomRepo = roomRepo;
            this.projRepo = projRepo;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            var projection = await this.projRepo.GetById(reservation.ProjectionId);
            var room = await this.roomRepo.GetById(projection.RoomId);

            //TODO get room ID

            if (reservation.Row < 0 || reservation.Row > room.SeatsPerRow ||
                reservation.Column < 0 || reservation.Column > room.Rows)
            {
                return new NewReservationSummary(false, $"Seat with position row: {reservation.Row}" +
                    $" and column: {reservation.Column} does not exist");
            }

            return await newReservation.New(reservation);
        }
    }
}
