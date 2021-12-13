using Booking.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<BookingModel> Get()
        {
            //return new string[] { "Sara", "Muhanad" };

            List<BookingModel> DBList = new List<BookingModel>();

            String selectAllDB = "Select * from booking";

            using (SqlConnection dataBaseConnection = new SqlConnection(ConnectionString))
            {
                dataBaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectAllDB, dataBaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int telephone = reader.GetInt32(2);
                            string email = reader.GetString(3);
                            DateTime date = reader.GetDateTime(4);
                            string note = reader.GetString(5);
                            // TimeSpan time = reader.GetTimeSpan(6);

                            DBList.Add(new BookingModel(name, telephone, email, date, note));
                        }
                    }
                }
            }

            return DBList;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] BookingModel value)
        {
            string insertSql =
                "insert into booking(name, telephone, email, date, note) values( @name, @telephone, @email, @date, @note)";

            using (SqlConnection dataBaseConnection = new SqlConnection(ConnectionString))
            {
                dataBaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertSql, dataBaseConnection))
                {
                    //insertCommand.Parameters.AddWithValue("@id", value.ID);
                    insertCommand.Parameters.AddWithValue("@name", value.Name);
                    insertCommand.Parameters.AddWithValue("@telephone", value.Telephone);
                    insertCommand.Parameters.AddWithValue("@email", value.Email);
                    insertCommand.Parameters.AddWithValue("@date", value.Date);
                    insertCommand.Parameters.AddWithValue("@note", value.Note);
                    var rowsAffected = insertCommand.ExecuteNonQuery();
                    Console.WriteLine($"Rows affected: {rowsAffected}");
                }
            }

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public BookingController()
        {

        }
    }
}
