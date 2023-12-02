using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulate_Fishing
{
    public class Positive_fish : Fish
    {
        public Bitmap textures = Resource1.Fish;
        public int speed = 2;
        public int score_p = 0;

        public Positive_fish()
        {
            score_p = score;
        }
    }
}
