using HeroBattle.Helpers;
using HeroBattle.Models;
using HeroBattle.Services;
using HeroBattle.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroBattle.Tests.ServiceTests
{
    public class BattleServiceTests
    {
        [Fact]
        public async void SimulateBattle_ShouldThrowError_WhenArenaNotFound()
        {
            // Arrange
            var mockService = new Mock<IArenaService>();
            mockService.Setup(x => x.GetArena(It.IsAny<Guid>())).ReturnsAsync((Arena)null);
            var service = new BattleService(mockService.Object);

            // Act
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => service.SimulateBattle(Guid.NewGuid()));

            // Assert
            Assert.Equal("Arena is not found!", exception.Message);
        }

        [Fact]
        public async void SimulateBattle_ReturnEmptyHistory_WhenArenaHeroesIsJustOnlyOne()
        {
            // Arrange
            var data = new Arena
            {
                Id = Guid.NewGuid(),
                Heroes = new List<Hero>
                {
                    new Hero
                    {
                        Id = 1,
                        Health = 100,
                        MaxHealth = 100,
                        Type = HeroType.Archer
                    }
                }
            };

            var mockService = new Mock<IArenaService>();
            mockService.Setup(x => x.GetArena(It.IsAny<Guid>())).ReturnsAsync(data);
            var service = new BattleService(mockService.Object);

            // Act
            var result = await service.SimulateBattle(Guid.NewGuid());

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async void SimulateBattle_ReturnHistory_WhenArenaHeroesAreMoreThanOne()
        {
            // Arrange
            var data = new Arena
            {
                Id = Guid.NewGuid(),
                Heroes = new List<Hero>
                {
                    new Hero
                    {
                        Id = 1,
                        Health = 100,
                        MaxHealth = 100,
                        Type = HeroType.Archer
                    },
                    new Hero
                    {
                        Id = 2,
                        Health = 100,
                        MaxHealth = 100,
                        Type = HeroType.Archer
                    }
                }
            };

            var mockService = new Mock<IArenaService>();
            mockService.Setup(x => x.GetArena(It.IsAny<Guid>())).ReturnsAsync(data);
            var service = new BattleService(mockService.Object);

            // Act
            var result = await service.SimulateBattle(Guid.NewGuid());

            // Assert
            Assert.NotEmpty(result);
            Assert.Single(result);
        }
    }
}
