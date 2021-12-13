using Booking.Model;
using Microsoft.EntityFrameworkCore;


namespace Booking
{
    public class BookingContext : DbContext
    {
        public DbSet<BookingModel> Bookings { get; set; }

        protected void OnCofiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }


    }
}
