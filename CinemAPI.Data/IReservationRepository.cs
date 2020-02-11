using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface IReservationRepository
    {
        Task Insert(IReservationCreation reservation);

        Task<IReservation> GetById(int id);

        Task RemoveReservation(int id);

        Task RemoveReservations(IEnumerable<IReservation> reservations);

        Task<int> RemoveAllReservations(long id);

        //Task<long> GetReservationUniqueID(IReservation reservation);
            //DateTime startDate, 
            //string movieName, 
            //string cinemaName, 
            //short roomNumber, 
            //short row, 
            //short column, 
            //long projectionId );
    }
}
