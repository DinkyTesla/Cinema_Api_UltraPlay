using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;
using CinemAPI.Models.Output.Reservation;
using CinemAPI.Models.Output.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemAPI.Models.ModelFactory
{
    public class ModelFactory : IModelFactory
    {
        public ReservationTicketModel Create(IReservation model)
        {
            return new ReservationTicketModel()
            {
                Id = model.Id,
                ProjectionStartDate = model.ProjectionStartDate,
                MovieName = model.MovieName,
                CinemaName = model.CinemaName,
                RoomNumber = model.RoomNumber,
                Row = model.Row,
                Column = model.Column
            };
        }

        public TicketModel Create(ITicket model)
        {
            return new TicketModel()
            {
                Id = model.Id,
                ProjectionStartDate = model.ProjectionStartDate,
                MovieName = model.MovieName,
                CinemaName = model.CinemaName,
                RoomNumber = model.RoomNumber,
                Row = model.Row,
                Column = model.Column
            };
        }
    }
}