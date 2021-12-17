using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.Model
{
    public class BookingModel
    {
        /// <summary>
        /// PROPERTIES
        /// </summary>

        /// <summary>
        /// Booking Id
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Client Name
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Client number. It had to be 8 number according with danish numbers
        /// </summary>
        /// 
        private int _telephone;
        [Required]
        public int Telephone
        {
            get
            {
                return _telephone;
                //_telephone.ToString();
            }
            set
            {
                string newS = value.ToString();
                if (newS.Length == 8)
                {
                    _telephone = value;
                }
                else { throw new ArgumentOutOfRangeException("Telefone nummer har 8 nummer, tak 😋 "); }
            }
        }
        /// <summary>
        /// Client's Email
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Date of the booking 
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
        /// <summary>
        /// Eventual Notes
        /// </summary>
        [Required]
        public string Note { get; set; }
        /// <summary>
        /// Time of the day
        /// </summary>
        //[Required]
        //public TimeSpan Time { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public BookingModel()
        {

        }

        /// <summary>
        /// constroctor with initialization
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="telephone"></param>
        /// <param name="email"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        /// <param name="time"></param>
        public BookingModel(string name, int telephone, string email, DateTime date, string note)
        {
            Name = name;
            Telephone = telephone;
            Email = email;
            Date = date;
            Note = note;
            //Time = time;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Tel.: {Telephone}, Email: {Email}, dayOfWeek: {Date}, Note: {Note}";
        }


    }
}
