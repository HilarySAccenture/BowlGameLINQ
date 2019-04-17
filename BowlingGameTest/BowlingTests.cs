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
        private Game _game = new Game();
        
        private void RollLots(int rolls, int pins)
        {
            for (var i = 0; i < rolls; i++)
            {
                _game.Roll(pins);
            }
        }
        
        [Fact]
        public void WhenRollingAllGutterBallsScoreIsZero()
        {
            RollLots(20, 0);

            var result = _game.Score();
            
            result.ShouldBe(0);
        }

        [Fact]
        public void WhenRollingOnePinScoreIsOne()
        {
            
            _game.Roll(1);
            RollLots(19,0);
            
            var result = _game.Score();
            
            result.ShouldBe(1);
        }
        
        [Fact]
        public void WhenRollingOnePinTwentyTimesScoreIsTwenty()
        {
            RollLots(20, 1);

            var result = _game.Score();
            
            result.ShouldBe(20);
        }

        [Fact(Skip = "Yep again")]
        public void WhenRollingSpareAndOneScoreShouldBeTwelve()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(1);
            RollLots(17, 0);

            var result = _game.Score();
            
            result.ShouldBe(12);
        }
    }

    
    
}
