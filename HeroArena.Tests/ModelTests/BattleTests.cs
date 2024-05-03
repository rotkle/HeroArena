using HeroBattle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroBattle.Tests.ModelTests
{
    public class BattleTests
    {
        [Fact]
        public void Attack_ShouldReturnCorrectResult_ArcherAttackArcher()
        {
            // Arrange
            var attacker = new Hero
            {
                Health = 100,
                Type = HeroType.Archer
            };

            var defender = new Hero
            {
                Health = 100,
                Type = HeroType.Archer
            };

            var expectedResult = new AttackResult { AttackerStatus = AttackStatus.NoEffect, DefenderStatus = AttackStatus.Dies, AttackerHealthChange = 50, DefenderHealthChange = 100 };

            // Atc
            var battle = new Battle(new Arena());
            var result = battle.Attack(attacker, defender);

            // Assert
            Assert.Equal(result.AttackerStatus, expectedResult.AttackerStatus);
            Assert.Equal(result.DefenderStatus, expectedResult.DefenderStatus);
            Assert.Equal(result.AttackerHealthChange, expectedResult.AttackerHealthChange);
            Assert.Equal(result.DefenderHealthChange, expectedResult.DefenderHealthChange);
        }

        [Fact]
        public void Attack_ShouldReturnCorrectResult_ArcherAttackSwordsman()
        {
            // Arrange
            var attacker = new Hero
            {
                Health = 100,
                Type = HeroType.Archer
            };

            var defender = new Hero
            {
                Health = 120,
                Type = HeroType.Swordsman
            };

            var expectedResult = new AttackResult { AttackerStatus = AttackStatus.NoEffect, DefenderStatus = AttackStatus.Dies, AttackerHealthChange = 50, DefenderHealthChange = 120 };

            // Atc
            var battle = new Battle(new Arena());
            var result = battle.Attack(attacker, defender);

            // Assert
            Assert.Equal(result.AttackerStatus, expectedResult.AttackerStatus);
            Assert.Equal(result.DefenderStatus, expectedResult.DefenderStatus);
            Assert.Equal(result.AttackerHealthChange, expectedResult.AttackerHealthChange);
            Assert.Equal(result.DefenderHealthChange, expectedResult.DefenderHealthChange);
        }

        [Fact]
        public void Attack_ShouldReturnCorrectResult_SwordsmanAttackSwordsman()
        {
            // Arrange
            var attacker = new Hero
            {
                Health = 120,
                Type = HeroType.Swordsman
            };

            var defender = new Hero
            {
                Health = 120,
                Type = HeroType.Swordsman
            };

            var expectedResult = new AttackResult { AttackerStatus = AttackStatus.NoEffect, DefenderStatus = AttackStatus.Dies, AttackerHealthChange = 60, DefenderHealthChange = 120 };

            // Atc
            var battle = new Battle(new Arena());
            var result = battle.Attack(attacker, defender);

            // Assert
            Assert.Equal(result.AttackerStatus, expectedResult.AttackerStatus);
            Assert.Equal(result.DefenderStatus, expectedResult.DefenderStatus);
            Assert.Equal(result.AttackerHealthChange, expectedResult.AttackerHealthChange);
            Assert.Equal(result.DefenderHealthChange, expectedResult.DefenderHealthChange);
        }

        [Fact]
        public void Attack_ShouldReturnCorrectResult_SwordsmanAttackHorseman()
        {
            // Arrange
            var attacker = new Hero
            {
                Health = 120,
                Type = HeroType.Swordsman
            };

            var defender = new Hero
            {
                Health = 150,
                Type = HeroType.Horseman
            };

            var expectedResult = new AttackResult { AttackerStatus = AttackStatus.NoEffect, DefenderStatus = AttackStatus.NoEffect, AttackerHealthChange = 60, DefenderHealthChange = 75 };

            // Atc
            var battle = new Battle(new Arena());
            var result = battle.Attack(attacker, defender);

            // Assert
            Assert.Equal(result.AttackerStatus, expectedResult.AttackerStatus);
            Assert.Equal(result.DefenderStatus, expectedResult.DefenderStatus);
            Assert.Equal(result.AttackerHealthChange, expectedResult.AttackerHealthChange);
            Assert.Equal(result.DefenderHealthChange, expectedResult.DefenderHealthChange);
        }

        [Fact]
        public void Attack_ShouldReturnCorrectResult_HorsemanAttackHorseman()
        {
            // Arrange
            var attacker = new Hero
            {
                Health = 150,
                Type = HeroType.Horseman
            };

            var defender = new Hero
            {
                Health = 150,
                Type = HeroType.Horseman
            };

            var expectedResult = new AttackResult { AttackerStatus = AttackStatus.NoEffect, DefenderStatus = AttackStatus.Dies, AttackerHealthChange = 75, DefenderHealthChange = 150 };

            // Atc
            var battle = new Battle(new Arena());
            var result = battle.Attack(attacker, defender);

            // Assert
            Assert.Equal(result.AttackerStatus, expectedResult.AttackerStatus);
            Assert.Equal(result.DefenderStatus, expectedResult.DefenderStatus);
            Assert.Equal(result.AttackerHealthChange, expectedResult.AttackerHealthChange);
            Assert.Equal(result.DefenderHealthChange, expectedResult.DefenderHealthChange);
        }

        [Fact]
        public void Attack_ShouldReturnCorrectResult_HorsemanAttackSwordsman()
        {
            // Arrange
            var attacker = new Hero
            {
                Health = 150,
                Type = HeroType.Horseman
            };

            var defender = new Hero
            {
                Health = 120,
                Type = HeroType.Swordsman
            };

            var expectedResult = new AttackResult { AttackerStatus = AttackStatus.Dies, DefenderStatus = AttackStatus.NoEffect, AttackerHealthChange = 150, DefenderHealthChange = 60 };

            // Atc
            var battle = new Battle(new Arena());
            var result = battle.Attack(attacker, defender);

            // Assert
            Assert.Equal(result.AttackerStatus, expectedResult.AttackerStatus);
            Assert.Equal(result.DefenderStatus, expectedResult.DefenderStatus);
            Assert.Equal(result.AttackerHealthChange, expectedResult.AttackerHealthChange);
            Assert.Equal(result.DefenderHealthChange, expectedResult.DefenderHealthChange);
        }

        [Fact]
        public void UpdateHealth_ShouldReturnCorrectResult_AttackerAndDefenderNotDies()
        {
            // Arrange
            var arena = new Arena
            {
                Heroes = new List<Hero>
                {
                    new Hero
                    {
                        Type = HeroType.Swordsman,
                        Id = 1,
                        Health = 120,
                        MaxHealth = 120
                    },
                    new Hero
                    {
                        Type = HeroType.Horseman,
                        Id = 2,
                        Health = 150,
                        MaxHealth = 150
                    },
                    new Hero
                    {
                        Type = HeroType.Archer,
                        Id = 3,
                        Health = 100,
                        MaxHealth = 100
                    }
                }
            };

            var attacker = arena.Heroes[0];

            var defender = arena.Heroes[1];

            var attackResult = new AttackResult { AttackerStatus = AttackStatus.NoEffect, DefenderStatus = AttackStatus.NoEffect, AttackerHealthChange = 60, DefenderHealthChange = 75 };

            // Act
            var battle = new Battle(arena);
            battle.UpdateHealth(attacker, defender, attackResult);

            // Assert
            Assert.Equal(60, attacker.Health);
            Assert.Equal(75, defender.Health);
            Assert.Equal(3, battle.Heroes.Count);
        }

        [Fact]
        public void UpdateHealth_ShouldReturnCorrectResult_AttackerDiesAndDefenderNotDies()
        {
            // Arrange
            var arena = new Arena
            {
                Heroes = new List<Hero>
                {
                    new Hero
                    {
                        Type = HeroType.Swordsman,
                        Id = 1,
                        Health = 120,
                        MaxHealth = 120
                    },
                    new Hero
                    {
                        Type = HeroType.Horseman,
                        Id = 2,
                        Health = 150,
                        MaxHealth = 150
                    },
                    new Hero
                    {
                        Type = HeroType.Archer,
                        Id = 3,
                        Health = 100,
                        MaxHealth = 100
                    }
                }
            };

            var attacker = arena.Heroes[1];

            var defender = arena.Heroes[0];

            var attackResult = new AttackResult { AttackerStatus = AttackStatus.Dies, DefenderStatus = AttackStatus.NoEffect, AttackerHealthChange = 150, DefenderHealthChange = 60 };

            // Act
            var battle = new Battle(arena);
            battle.UpdateHealth(attacker, defender, attackResult);

            // Assert
            Assert.Equal(0, attacker.Health);
            Assert.Equal(60, defender.Health);
            Assert.Equal(2, battle.Heroes.Count);
        }

        [Fact]
        public void UpdateHealth_ShouldReturnCorrectResult_AttackerNotDiesAndDefenderDies()
        {
            // Arrange
            var arena = new Arena
            {
                Heroes = new List<Hero>
                {
                    new Hero
                    {
                        Type = HeroType.Swordsman,
                        Id = 1,
                        Health = 120,
                        MaxHealth = 120
                    },
                    new Hero
                    {
                        Type = HeroType.Horseman,
                        Id = 2,
                        Health = 150,
                        MaxHealth = 150
                    },
                    new Hero
                    {
                        Type = HeroType.Archer,
                        Id = 3,
                        Health = 100,
                        MaxHealth = 100
                    }
                }
            };

            var attacker = arena.Heroes[2];

            var defender = arena.Heroes[0];

            var attackResult = new AttackResult { AttackerStatus = AttackStatus.NoEffect, DefenderStatus = AttackStatus.Dies, AttackerHealthChange = 50, DefenderHealthChange = 120 };

            // Act
            var battle = new Battle(arena);
            battle.UpdateHealth(attacker, defender, attackResult);

            // Assert
            Assert.Equal(50, attacker.Health);
            Assert.Equal(0, defender.Health);
            Assert.Equal(2, battle.Heroes.Count);
        }

        [Fact]
        public void UpdateHealth_ShouldReturnCorrectResult_AttackerAndDefenderBothDies()
        {
            // Arrange
            var arena = new Arena
            {
                Heroes = new List<Hero>
                {
                    new Hero
                    {
                        Type = HeroType.Swordsman,
                        Id = 1,
                        Health = 120,
                        MaxHealth = 120
                    },
                    new Hero
                    {
                        Type = HeroType.Horseman,
                        Id = 2,
                        Health = 150,
                        MaxHealth = 150
                    },
                    new Hero
                    {
                        Type = HeroType.Archer,
                        Id = 3,
                        Health = 40,
                        MaxHealth = 100
                    }
                }
            };

            var attacker = arena.Heroes[2];

            var defender = arena.Heroes[0];

            var attackResult = new AttackResult { AttackerStatus = AttackStatus.NoEffect, DefenderStatus = AttackStatus.Dies, AttackerHealthChange = 20, DefenderHealthChange = 120 };

            // Act
            var battle = new Battle(arena);
            battle.UpdateHealth(attacker, defender, attackResult);

            // Assert
            Assert.Equal(20, attacker.Health);
            Assert.Equal(0, defender.Health);
            Assert.Single(battle.Heroes);
        }
    }
}
