using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace BowlingGame
{
    public class Game
    {
        private int[] _rolls = new int[20];
        private int _currentRoll = 0;
        
        public void Roll(int pins)
        {
            _rolls[_currentRoll] = pins;
            _currentRoll++;
        }

        public int Score()
        {
            var frames = MakeListOfFrames();

            var spares = frames.Where(frame => frame.Rolls.Sum() == 10).ToList();
            var spareScore = spares.Sum(spare => 10 + frames[frames.IndexOf(spare) + 1].Rolls[0]);
            var regularFrames = frames.Where(frame => frame.Rolls.Sum() != 10).ToList();
            var regularScore = regularFrames.Sum(frame => frame.Rolls.Sum());
            
            
            return spareScore + regularScore;
        }

        private List<Frame> MakeListOfFrames()
        {
            var frames = new List<Frame>();
            var frameCount = 1;
            
            for (var i = 0; i < 21; i++)
            {
                if (i % 2 == 0 && i > 0)
                {
                    frames.Add(new Frame
                    {
                        FrameNumber = frameCount, 
                        Rolls = new []
                        { 
                            _rolls[i-2],
                            _rolls[i-1]
                        }
                    });
                    
                    frameCount++;
                }
            }

            return frames;
        }
    }
}