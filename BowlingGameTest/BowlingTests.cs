using System;
using System.Resources;
using BowlingGame;
using Xunit;
using Shouldly;
using Xunit.Sdk;

namespace BowlingGameTest
{
    public class BowlingTests
    {
        private readonly Game game = new Game();
        private int rollCount = 0;

        [Fact]
        public void RollOnePinOnlyScoreIsOne()
        {
        Game game = new Game();
            game.Roll(1);
            rollMany(game, 19, 0);
            
            var actualScore = game.Score();
            
            actualScore.ShouldBe(1);
        }

        [Fact]
        public void RollOnePinTwentyTimesScoreIsTwenty()
        {
            Game game = new Game();
            rollMany(game, 20, 1);

            var actualScore = game.Score();
            
            actualScore.ShouldBe(20);
        }

        [Fact]
        public void RollASpareThenRollOnePinScoreIsTwelve()
        {
            Game game = new Game();
            game.Roll(5);
            game.Roll(5);
            game.Roll(1);
            rollMany(game, 17, 0);

            var actualScore = game.Score();
            
            actualScore.ShouldBe(12);

        }

        private static void rollMany(Game game, int rollCount, int pins)
        {
            for (int i = 0; i < rollCount; i++)
            {
                game.Roll(pins);
            }
        } 
        
   
        
    }

    
    
}
