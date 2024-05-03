using HeroBattle.Helpers;
using HeroBattle.Models;
using HeroBattle.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroBattle.Tests.ServiceTests
{
    public class ArenaServiceTests
    {
        [Fact]
        public async void GenerateArena_ShouldThrowError_WhenNumberHeroesIsLessThan0()
        {
            // Arrange
            var mockContext = new Mock<DataContext>();
            var service = new ArenaService(mockContext.Object);

            // Act
            var exception = await Assert.ThrowsAsync<AppException>(() => service.GenerateArena(-1));

            // Assert
            Assert.Equal("Number of Heroes must be greater than 0", exception.Message);
        }

        [Fact]
        public async void GenerateArena_ShouldThrowError_WhenNumberHeroesIsEqual0()
        {
            // Arrange
            var mockContext = new Mock<DataContext>();
            var service = new ArenaService(mockContext.Object);

            // Act
            var exception = await Assert.ThrowsAsync<AppException>(() => service.GenerateArena(0));

            // Assert
            Assert.Equal("Number of Heroes must be greater than 0", exception.Message);
        }

        [Fact]
        public async void GenerateArena_ShouldGenerateArenaSuccessful_WhenNumberHeroesGreaterThan0()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<Arena>>();
            var mockContext = new Mock<DataContext>();
            mockContext.Setup(x => x.Arenas).Returns(mockDbSet.Object);
            mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Verifiable();
            var service = new ArenaService(mockContext.Object);

            // Act
            var result = await service.GenerateArena(10);

            // Assert
            Assert.IsType<Guid>(result);
            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
