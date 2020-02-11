using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Reservation;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationCreation : INewReservation
    {
        private readonly IProjectionRepository projRepo;
        private readonly IMovieRepository movieRepo;
        private readonly IRoomRepository roomRepo;
        private readonly IReservationRepository reservationRepo;
        private readonly ICinemaRepository cinemaRepo;

        public NewReservationCreation(
            IProjectionRepository projRepo, 
            IMovieRepository movieRepo,
            IRoomRepository roomRepo, 
            IReservationRepository reservationRepo, 
            ICinemaRepository cinemaRepo)
        {
            this.projRepo = projRepo;
            this.movieRepo = movieRepo;
            this.roomRepo = roomRepo;
            this.reservationRepo = reservationRepo;
            this.cinemaRepo = cinemaRepo;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            IProjection projection = await this.projRepo.GetById(reservation.ProjectionId);

            await this.projRepo.DecreaseAvailableSeats(projection.Id);

            string movieName = await this.movieRepo.GetMovieNameById(projection.MovieId);

            var room = await this.roomRepo.GetById(projection.RoomId);

            string cinemaName = await this.cinemaRepo.GetCinemaNameById(room.CinemaId);

            var newReservation = new Reservation(
                    projection.StartDate,
                    movieName,
                    cinemaName,
                    room.Number,
                    reservation.Row,
                    reservation.Column,
                    projection.Id);

            await this.reservationRepo.Insert(newReservation);

            newReservation.Id = newReservation.Id;

            var result = new NewReservationSummary(true)
            {
                Reservation = newReservation
            };

            return result;
        }
    }
}
