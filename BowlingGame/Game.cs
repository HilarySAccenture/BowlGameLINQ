using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace BowlingGame
{
    public class Game
    {
        private int[] _currentScore = new int[20];
        private int _currentRoll;
        
        public void Roll(int pins)
        {
            _currentScore[_currentRoll] = pins;
            _currentRoll++;
        }

        public int Score()
        {
            return _currentScore.Sum();
        }

    }
}