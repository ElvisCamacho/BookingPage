using Microsoft.VisualStudio.TestTools.UnitTesting;
using Booking.Controllers;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace MSTest_BookingPage
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForSuccesfulObjCreation()
        {
            //act
            BookingModel b = new BookingModel("hans", 5555, "hans", DateTime.Today, "hans");

            //assert
            Assert.AreEqual("Name: hans, Tel.: 5555, Email: hans, dayOfWeek: 17-Dec-21 00:00:00, Note: hans", b.ToString());

        }

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


        [TestMethod]
        public void CompareRealDataFromDB_with_fakeBookingData()
        {
            //................Act............

            var expected = FakeBookingData();
            // fake data from  own unit test class
            var controller = new BookingController();

            // .............Arrange........and  define a type which you get the object
            var result = controller.Get() as List<BookingModel>;

            //............Asset..............
            //Assert.IsNotNull(expected);
            Assert.AreEqual(expected[0].Name, result[0].Name);
            Assert.AreEqual(expected[0].Telephone, result[0].Telephone);
            Assert.AreEqual(expected[0].Email, result[0].Email);
            Assert.AreEqual(expected[0].Note, result[0].Note);


        }

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


        public List<BookingModel> FakeBookingData()
        {
            List<BookingModel> booking = new List<BookingModel>
            {
                new BookingModel("Elvis", 83483483,"camachocv@hotmail.com", DateTime.Parse("12.jan.21"),  "lsdihflsahd"),
                new BookingModel("Muhanad", 834834834,"camachocv@hotmail.com", DateTime.Parse("12.jan.21"),  "lsdihflsahd")
            };
            return booking;
        }


       // ********* about tests are on git - all passed ***************


    }
}
   