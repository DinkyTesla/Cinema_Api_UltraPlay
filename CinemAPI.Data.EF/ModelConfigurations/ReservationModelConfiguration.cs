using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using CinemAPI.Models;

namespace CinemAPI.Data.EF.ModelConfigurations
{
    internal sealed class ReservationModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Reservation> reservationModel = modelBuilder.Entity<Reservation>();
            reservationModel.HasKey(model => model.Id);
            reservationModel.Property(model => model.ProjectionStartDate).IsRequired();
            reservationModel.Property(model => model.MovieName).IsRequired();
            reservationModel.Property(model => model.CinemaName).IsRequired();
            reservationModel.Property(model => model.RoomNumber).IsRequired();
            reservationModel.Property(model => model.Row).IsRequired();
            reservationModel.Property(model => model.Column).IsRequired();

            reservationModel
                .HasRequired(x => x.Projection)
                .WithMany(i => i.Reservations)
                .HasForeignKey(f => f.ProjectionId);
        }
    }
}
