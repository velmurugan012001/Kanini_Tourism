using Kanini_Toursim.Controllers;
using Kanini_Toursim.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace TourismTesting.Tests
{
    public class PackageControllerTests
    {


        [Fact]
        public void AddPackage_ReturnsCreatedAtAction()
        {
            // Arrange
            var mockRepository = new Mock<IPackageRepository>();
            var package = new Package { PackageID = 3, HotelName = "New Package" };
            var controller = new PackageController(mockRepository.Object);

            // Act
            var result = controller.AddPackage(package);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(controller.GetPackageById), createdAtActionResult.ActionName);
            Assert.Equal(3, createdAtActionResult.RouteValues["packageId"]);
        }

        // Similar test cases can be added for UpdatePackage and DeletePackage actions
        // Make sure to mock the repository methods and test different scenarios.

        // Helper method to generate test packages

      

        [Fact]
        public void AddPackage_ReturnsBadRequest_ForInvalidModel()
        {
            // Arrange
            var mockRepository = new Mock<IPackageRepository>();
            var controller = new PackageController(mockRepository.Object);
            controller.ModelState.AddModelError("Name", "Name is required"); // Simulate invalid model state

            // Act
            var package = new Package { HotelName = null }; // Invalid package
            var result = controller.AddPackage(package);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdatePackage_ReturnsNotFound_ForNonExistentPackage()
        {
            // Arrange
            var mockRepository = new Mock<IPackageRepository>();
            var packageId = 1;
            var controller = new PackageController(mockRepository.Object);
            mockRepository.Setup(repo => repo.GetPackageById(packageId))
                          .Returns((Package)null); // Simulate non-existent package

            // Act
            var updatedPackage = new Package { PackageID = packageId, HotelName = "Updated Package" };
            var result = controller.UpdatePackage(packageId, updatedPackage);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
