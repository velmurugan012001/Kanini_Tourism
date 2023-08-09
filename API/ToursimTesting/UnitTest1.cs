using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Travel.Models;
using Travel.Repository.Interface;
using Travel.Controllers;
using Kanini_Toursim.Model;

namespace Travel.Tests
{
    [TestFixture]
    public class UsersControllerTests
    {
        private UsersController _controller;
        private Mock<IAdminUseService> _mockUserService;

        [SetUp]
        public void Setup()
        {
            _mockUserService = new Mock<IAdminUseService>();
            _controller = new UsersController(_mockUserService.Object);
        }

        [Test]
        public async Task Register_ValidUser_ReturnsToken()
        {
            // Arrange
            var user = new Admin_User { /* Set user properties */ };
            _mockUserService.Setup(repo => repo.AddUser(It.IsAny<Admin_User>()))
                           .ReturnsAsync(user);

            // Act
            var result = await _controller.Register(user);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            // Add more assertions as needed
        }

        [Test]
        public async Task Login_ValidCredentials_ReturnsToken()
        {
            // Arrange
            var existingUser = new Admin_User { EmailId = "test@example.com", Password = "encryptedPassword", IsActive = true };
            _mockUserService.Setup(repo => repo.GetUserByEmail(It.IsAny<string>()))
                           .ReturnsAsync(existingUser);

            // Act
            var result = await _controller.Login(new Admin_User { EmailId = "test@example.com", Password = "password" });

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            // Add more assertions as needed
        }

        // Add more test cases for other controller actions

    }
}

[TestFixture]
public class PackageRepositoryTests
{
    private PackageRepository _repository;
    private Mock<KaniniTourismDbContext> _mockDbContext;

    [SetUp]
    public void Setup()
    {
        _mockDbContext = new Mock<KaniniTourismDbContext>();
        _repository = new PackageRepository(_mockDbContext.Object);
    }

    [Test]
    public void GetAllPackages_ReturnsListOfPackages()
    {
        // Arrange
        var packages = new List<Package> { new Package { PackageID = 1, OfferingType = "Vacation", Destination = "Beach Paradise", /* Set other properties */ } };
        _mockDbContext.Setup(db => db.Packages.ToList()).Returns(packages);

        // Act
        var result = _repository.GetAllPackages();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(packages.Count, result.Count());
        // Add more assertions as needed
    }

    [Test]
    public void GetPackageById_ValidPackageId_ReturnsPackage()
    {
        // Arrange
        var packageId = 1;
        var package = new Package { PackageID = packageId, OfferingType = "Vacation", Destination = "Beach Paradise", /* Set other properties */ };
        _mockDbContext.Setup(db => db.Packages.FirstOrDefault(p => p.PackageID == packageId)).Returns(package);

        // Act
        var result = _repository.GetPackageById(packageId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(packageId, result.PackageID);
        // Add more assertions as needed
    }

    [Test]
    public void AddPackage_ValidPackage_AddedSuccessfully()
    {
        // Arrange
        var package = new Package
        {
            OfferingType = "Vacation",
            Destination = "Beach Paradise",
            Location = "Tropical Island",
            Days = 7,
            Nights = 6,
            Totaldays = 7,
            ItineraryDetails = "Enjoy a relaxing vacation on a beautiful tropical island.",
            PricePerPerson = "$1500",
            HotelName = "Palm Resort",
            HotelPlace = "Beachfront",
            HotelImage = "hotel_image.jpg",
            FoodType = "All-Inclusive",
            BedType = "King Bed",
            VehicleType = "Private Shuttle",
            ToDate = DateTime.Now.AddDays(30),
            FromDate = DateTime.Now.AddDays(37),
            Facilities = "Swimming Pool, Spa, Restaurants",
            Itinerary = "Day 1: Arrival and Check-in...",
            ActivitiesName = "Beach Yoga",
            Description = "Start your day with calming beach yoga...",
            Duration = 7,
            ActivitiesImageUrl = "yoga_image.jpg",
            UserId = 1 // Assuming a valid user ID
        };


        // Act
        _repository.AddPackage(package);

        // Assert
        _mockDbContext.Verify(db => db.Packages.Add(package), Times.Once);
        _mockDbContext.Verify(db => db.SaveChanges(), Times.Once);
    }

    // Add more test cases for other repository methods (UpdatePackage, DeletePackage, etc.)

}
