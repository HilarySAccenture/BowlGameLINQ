using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace BowlingGame
{
    public class Game
    {
        List<int> rolls = new List<int>();

        public void Roll(int pins)
        {
            rolls.Add(pins);
        }

        public int Score()
        {
            var currentScore = 0;
            var currentId = 0;

            var firstRolls= rolls.Where((roll, i) => i % 2 == 0).ToList();
            var secondRolls = rolls.Where((roll, i) => (i + 1) % 2 == 0).ToList();

            var frames = firstRolls.Select(roll => new
                {rollOne = roll, rollTwo = secondRolls[firstRolls.IndexOf(roll)], frameIndex = currentId++}).ToList();

            var openFrames = frames.Where(frame => frame.rollOne + frame.rollTwo != 10);
            currentScore += openFrames.Sum(frame => frame.rollOne + frame.rollTwo);

            //replace openframes with currentscore, tack on sum to line 28
            var spares = frames.Where(frame => frame.rollOne + frame.rollTwo == 10);
            currentScore += spares.Sum(frame => 10 + frames[frame.frameIndex + 1].rollOne);
            
            //where can I combine these into a single step? 
            
            return currentScore; 
            
        }

    }
}