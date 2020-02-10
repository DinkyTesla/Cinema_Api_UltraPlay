using CinemAPI.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CinemAPI.Data.EF.ModelConfigurations
{
    internal sealed class TicketModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Ticket> ticketModel = modelBuilder.Entity<Ticket>();
            ticketModel.HasKey(model => model.Id);
            ticketModel.Property(model => model.ProjectionStartDate).IsRequired();
            ticketModel.Property(model => model.MovieName).IsRequired();
            ticketModel.Property(model => model.CinemaName).IsRequired();
            ticketModel.Property(model => model.RoomNumber).IsRequired();
            ticketModel.Property(model => model.Row).IsRequired();
            ticketModel.Property(model => model.Column).IsRequired();

            ticketModel
                 .HasRequired(x => x.Projection)
                 .WithMany(t => t.Tickets)
                 .HasForeignKey(f => f.ProjectionId);
        }
    }
}
