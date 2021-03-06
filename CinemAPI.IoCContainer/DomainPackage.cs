﻿using CinemAPI.Domain;
using CinemAPI.Domain.AvailableSeatProjection;
using CinemAPI.Domain.BuyTicketReservation;
using CinemAPI.Domain.Contracts.Models.CinemaModels;
using CinemAPI.Domain.Contracts.Models.MovieModels;
using CinemAPI.Domain.Contracts.Models.ProjectionModels;
using CinemAPI.Domain.Contracts.Models.Reservation;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Domain.Contracts.Models.RoomModels;
using CinemAPI.Domain.Contracts.Models.Ticket;
using CinemAPI.Domain.DeleteReservation;
using CinemAPI.Domain.NewCinema;
using CinemAPI.Domain.NewMovie;
using CinemAPI.Domain.NewProjection;
using CinemAPI.Domain.NewReservation;
using CinemAPI.Domain.NewRoom;
using CinemAPI.Domain.NewTicket;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace CinemAPI.IoCContainer
{
    public class DomainPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            //Projections
            container.Register<INewProjection, NewProjectionCreation>();
            container.RegisterDecorator<INewProjection, NewProjectionPreviousOverlapValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionNextOverlapValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionMovieValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionRoomValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionSeatValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionUniqueValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionPastTimeValidation>();
            
            //Seats to add functionality.
            container.Register<IAvailableSeatsProjection, AvailableSeatProjectionStartedValidation>();
            container.RegisterDecorator<IAvailableSeatsProjection, AvailableSeatProjectionValidation>();
            
            //Cinema
            container.Register<INewCinema, NewCinemaCreation>();
            container.RegisterDecorator<INewCinema, NewCinemaUniqueValidation>();

            //Movie
            container.Register<INewMovie, NewMovieCreation>();
            container.RegisterDecorator<INewMovie, NewMovieUniqueValidation>();
          
            //Movie
            container.Register<INewRoom, NewRoomCreation>();
            container.RegisterDecorator<INewRoom, NewRoomCinemaValidation>();
            container.RegisterDecorator<INewRoom, NewRoomUniqueValidation>();
         
            //Room
            container.Register<INewReservation, NewReservationCreation>();
            container.RegisterDecorator<INewReservation, NewReservationCheckIfSeatAvailableValidation>();
            container.RegisterDecorator<INewReservation, NewReservationProjectionStartingValidation>();
            container.RegisterDecorator<INewReservation, NewReservationLateValidation>();
            container.RegisterDecorator<INewReservation, NewReservationSeatValidation>();
            container.RegisterDecorator<INewReservation, NewReservationProjectionValidation>();

            //Reservations
            container.Register<IDeleteReservation, DeleteReservation>();
            container.RegisterDecorator<IDeleteReservation, DeleteReservationUniqueValidation>();

            //Tickets
            container.Register<INewTicket, NewTicketCreation>();
            container.RegisterDecorator<INewTicket, NewTicketCheckIfSeatAvailableValidation>();
            container.RegisterDecorator<INewTicket, NewTicketLateValidation>();
            container.RegisterDecorator<INewTicket, NewTicketSeatValidation>();
            container.RegisterDecorator<INewTicket, NewTicketCheckIfAvailableProjection>();

            container.Register<IBuyTicket, BuyTicketCreation>();
            container.RegisterDecorator<IBuyTicket, BuyTicketReservationExpiredValidation>();
            container.RegisterDecorator<IBuyTicket, BuyTicketLateValidation>();
            container.RegisterDecorator<IBuyTicket, BuyTicketReservationValidation>();
        }
    }
}