using Azure;
using Booking.Controllers;
using Booking.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace MSTest_BookingPage
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// testing full object criation
        /// </summary>
        [TestMethod]
        public void TestForSuccesfulObjCreation()
        {
            //act
            BookingModel b = new BookingModel("hans", 44445555, "hans", DateTime.Today, "hans");

            //assert
            Assert.AreEqual("Name: hans, Tel.: 44445555, Email: hans, dayOfWeek: 17-Dec-21 00:00:00, Note: hans", b.ToString());
        }

        /// <summary>
        /// return all booking From DB
        /// </summary>
        [TestMethod]
        public void shouldReturnAllBooking()
        {
            //................Act............
            BookingController ex = new BookingController();
            var expected = ex.Get();
            // fake data from  own unit test class
            var controller = new BookingController();

            // .............Arrange...........
            // loading data from controler methods
            var actual = controller.Get() as List<BookingModel>; // as List<Elephants> to prevent the problem on run time

            //............Asset..............

            Assert.IsNotNull(actual);
            Assert.IsNotNull(controller);
        }

        /// <summary>
        /// Comparing the real data from DB with a fake data
        /// however the fake data is the same as the DB. 
        /// so we compare that we are getting the right data from Db
        /// </summary>
        [TestMethod]
        public void CompareRealDataFromDB_with_fakeBookingData()
        {
            //................Act............

            var expected = FakeBookingData(); // fake data from  own unit test class
            var controller = new BookingController();

            // .............Arrange........and  define a type which you get the object
            var result = controller.Get() as List<BookingModel>;

            //............Asset..............
            Assert.AreEqual(expected[0].Name, result[0].Name);
            Assert.AreEqual(expected[0].Telephone, result[0].Telephone);
            Assert.AreEqual(expected[0].Email, result[0].Email);
            Assert.AreEqual(expected[0].Note, result[0].Note);


        }

        /// <summary>
        /// Asser not null Result
        /// </summary>
        [TestMethod]
        public void AssertNotNullResult()
        {
            //................Act............
            var expected = FakeBookingData();
            // fake data from  own unit test class
            var controller = new BookingController();

            // .............Arrange........and  define a type which you get the object
            var result = controller.Get() as List<BookingModel>; //we need object value
            var actual = result;

            //............Asset..............
            Assert.IsNotNull(result);
            Debug.Assert(expected != null, nameof(expected) + " != null");
        }


        /// <summary>
        /// fake data -  helper method from test
        /// </summary>
        /// <returns></returns>
        public List<BookingModel> FakeBookingData()
        {
            List<BookingModel> booking = new List<BookingModel>
            {
                new BookingModel("Muhanad", 83483483,"camachocv@hotmail.com", DateTime.Parse("12.jan.21"),  "lsdihflsahd"),
                new BookingModel("Muhanad", 83483434,"camachocv@hotmail.com", DateTime.Parse("12.jan.21"),  "lsdihflsahd")
            };
            return booking;
        }


        /// <summary>
        /// testing if we are getting the write number length from DB
        /// </summary>
        [TestMethod]
        public void GetTheRightNumberLength()
        {
            var expected = FakeBookingData();
            string expectedTelephoneLength = expected[0].Telephone.ToString();

            var controller = new BookingController();
            var result = controller.Get() as List<BookingModel>;
            var telephoneLenght = result[0].Telephone.ToString();

            Assert.AreEqual(expectedTelephoneLength.Length, telephoneLenght.Length);

        }


        /// <summary>
        /// testing if the client imput have from length 
        /// </summary>
        [TestMethod]
        public void Incorrect_Telephone_Length()
        {
            BookingModel book = new BookingModel();

            try
            {
                book.Telephone = 1234567;
            }

            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }

            Assert.Fail();
        }


        /// <summary>
        /// Getting the write number from DB
        /// </summary>
        [TestMethod]
        public void GetByTelephoneNumber()
        {
            var controller = new BookingController();

            // .............Arrange........and  define a type which you get the object
            var Getbyphone = controller.GetTelephone(3483483) as OkObjectResult;

            //............Asset..............
            Assert.IsNotNull(Getbyphone);

        }

        /// <summary>
        /// Get all booking from DB
        /// </summary>
        [TestMethod]
        public void Should_GetBookingFromDB()
        {
            //................Act............
            BookingController ex = new BookingController();
            // fake data from  own unit test class

            // .............Arrange...........
            // loading data from controler methods
            var newObj = ex.GetBookingFromDB($"select name, telephone, email, date, note from booking where telephone=telephone");
            // problem on run time

            //............Asset..............

            Assert.IsNotNull(newObj);
        }

        //[TestMethod]
        //public void Test_PostControler()
        //{


        //    var p = new BookingModel()
        //    {
        //        Id = 12,
        //        Name = "Elvis",
        //        Telephone = 83483483,
        //        Email = "camachocv@hotmail.com",
        //        Date = DateTime.Parse("12.jan.21"),
        //        Note = "lsdihflsahd"
        //    };

        //    BookingController controller = new BookingController();

        //    //Act
        //    //IHttpActionResult cc = controller.Post(BookingModel
        //    //{
        //    //    Id = 12,
        //    //    Name = "Elvis",
        //    //    Telephone = 83483483,
        //    //    Email = "camachocv@hotmail.com",
        //    //    Date = DateTime.Parse("12.jan.21"),
        //    //    Note = "lsdihflsahd"
        //    //});


        //    var cc = controller.Post(p);

        //    //Assert
        //    Assert.AreEqual();

        //}




    }
}
