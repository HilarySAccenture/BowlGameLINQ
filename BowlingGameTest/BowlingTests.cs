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
        [Fact]
        public void WhenRollingAllGutterBallsScoreIsZero()
        {
            var game = new Game();

            for (var i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            var result = game.Score();
            
            result.ShouldBe(0);
        }
    }

    
    
}
