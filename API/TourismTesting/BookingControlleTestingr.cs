using Kanini_Toursim.Controllers;
using Kanini_Toursim.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Kanini_Toursim.Tests
{
    public class TripBookingsControllerTests
    {
        [Fact]
        public async Task GetTripBookings_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<IBookingRepository>();
            var controller = new TripBookingsController(mockRepository.Object);

            var mockTripBookings = new List<Booking>
            {
                new Booking { BookingTripId = 1, Name = "Customer A" },
                new Booking { BookingTripId = 2, Name = "Customer B" }
            };

            mockRepository.Setup(repo => repo.GetTripBookings())
                          .ReturnsAsync(mockTripBookings);

            // Act
            var result = await controller.GetTripBookings();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTripBookings = Assert.IsAssignableFrom<List<Booking>>(okResult.Value);
            Assert.Equal(2, returnedTripBookings.Count);
        }

        [Fact]
        public async Task PostTripBooking_ReturnsCreatedAtAction()
        {
            // Arrange
            var mockRepository = new Mock<IBookingRepository>();
            var controller = new TripBookingsController(mockRepository.Object);

            var newBooking = new Booking
            {
                BookingTripId = 3,
                Name = "New Customer",
                NumberOfPeople = 2,
                TripType = "Adventure",
                ContactNumber = 1234567890,
                DateOfTheTrip = DateTime.Now.AddDays(7),
                TotalAmount = 500.00m,
                DateOfBooking = DateTime.Now
            };

            mockRepository.Setup(repo => repo.PostTripBooking(It.IsAny<Booking>()))
                          .ReturnsAsync(newBooking);

            // Act
            var result = await controller.PostTripBooking(newBooking);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedBooking = Assert.IsAssignableFrom<Booking>(createdAtActionResult.Value);

            Assert.Equal("New Customer", returnedBooking.Name);
            Assert.Equal(2, returnedBooking.NumberOfPeople);
            Assert.Equal("Adventure", returnedBooking.TripType);
            Assert.Equal(1234567890, returnedBooking.ContactNumber);
            Assert.Equal(newBooking.DateOfTheTrip, returnedBooking.DateOfTheTrip);
            Assert.Equal(500.00m, returnedBooking.TotalAmount);
            Assert.Equal(newBooking.DateOfBooking, returnedBooking.DateOfBooking);
        }
    }
}