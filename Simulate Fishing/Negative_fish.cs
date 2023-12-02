using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulate_Fishing
{
    public class Negative_fish : Fish
    {
        public Bitmap textures = Resource1.Fish_n;
        public int speed = 1;
        public int score_n = 0;

        public Negative_fish()
        {
            score_n = score;
        }
    }
}
