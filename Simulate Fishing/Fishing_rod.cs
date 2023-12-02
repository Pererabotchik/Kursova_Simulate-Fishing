using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulate_Fishing
{
    internal class Fishing_rod
    {
       public Bitmap poplavok = Resource1.spin;
      
       public void Set_poplavok()
        {
            poplavok = Resource1.spin;
        }
       
        public void Set_spining()
        {
            poplavok = Resource1.pop;
        }
    }
}
