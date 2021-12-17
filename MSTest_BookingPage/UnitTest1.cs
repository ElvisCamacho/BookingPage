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
        [TestMethod]
        public void TestForSuccesfulObjCreation()
        {
            //act
            BookingModel b = new BookingModel("hans", 44445555, "hans", DateTime.Today, "hans");

            //assert
            Assert.AreEqual("Name: hans, Tel.: 44445555, Email: hans, dayOfWeek: 17-Dec-21 00:00:00, Note: hans", b.ToString());
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
                new BookingModel("Muhanad", 83483434,"camachocv@hotmail.com", DateTime.Parse("12.jan.21"),  "lsdihflsahd")
            };
            return booking;
        }

        // ********* about tests are on git - all passed ***************


        [TestMethod]
        public void GetTheRightNumberLength()
        {
            var expected = FakeBookingData();
            string newString = expected[0].Telephone.ToString();

            var controller = new BookingController();
            var result = controller.Get() as List<BookingModel>;
            var stringResult = result[0].Telephone.ToString();

            var actual = result;
            Assert.AreEqual(newString.Length, stringResult.Length);

        }

        [TestMethod]
        public void Incorrect_TelephoneNummer()
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


        [TestMethod]
        public void GetByTelephoneNumber()
        {
            var controller = new BookingController();

            // .............Arrange........and  define a type which you get the object
            var Getbyphone = controller.GetTelephone(3483483) as OkObjectResult;

            //............Asset..............
            Assert.IsNotNull(Getbyphone);

        }

        [TestMethod]
        public void Should_GetBookingFromDB()
        {
            //................Act............
            BookingController ex = new BookingController();
            // fake data from  own unit test class

            // .............Arrange...........
            // loading data from controler methods
            var newee = ex.GetBookingFromDB($"select name, telephone, email, date, note from booking where telephone=telephone");
            // problem on run time

            //............Asset..............

            Assert.IsNotNull(newee);
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
        //    IHttpActionResult  cc = controller.Post(BookingModel
        //    {
        //        Id = 12,
        //        Name = "Elvis",
        //        Telephone = 83483483,
        //        Email = "camachocv@hotmail.com",
        //        Date = DateTime.Parse("12.jan.21"),
        //        Note = "lsdihflsahd"
        //    });
        //    var cc = createdResult   as CreatedAtRouteNegotiatedContentResult<Boo>;

        //    //Assert
        //    Assert.AreEqual(response.StatusCode, 201);

        //}




    }
}
