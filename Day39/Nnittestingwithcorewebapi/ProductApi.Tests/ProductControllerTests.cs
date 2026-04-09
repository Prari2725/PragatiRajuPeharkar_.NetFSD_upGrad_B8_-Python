using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductApi.Controllers;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Tests
{

    public class ProductControllerTests
    {
        private Mock<IProductService> _mockService;
        private ProductController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IProductService>();
            _controller = new ProductController(_mockService.Object);
        }

        [Test]
        public void GetAll_ReturnsOkResult()
        {
            // Arrange
            _mockService.Setup(s => s.GetAll()).Returns(new List<Product>
            {
                new Product { Id = 1, Name = "Test", Price = 100 }
            });

            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void GetById_ProductExists_ReturnsOk()
        {
            _mockService.Setup(s => s.GetById(1))
                        .Returns(new Product { Id = 1, Name = "Laptop", Price = 50000 });

            var result = _controller.GetById(1);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void GetById_ProductNotFound_ReturnsNotFound()
        {
            _mockService.Setup(s => s.GetById(5))
                        .Returns((Product)null);

            var result = _controller.GetById(5);

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
    }
}
