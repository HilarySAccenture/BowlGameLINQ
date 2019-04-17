using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace BowlingGame
{
    public class Game
    {
        private int _currentScore;
        
        public void Roll(int pins)
        {
            _currentScore += pins;
        }

        public int Score()
        {
            return _currentScore;
        }

    }
}