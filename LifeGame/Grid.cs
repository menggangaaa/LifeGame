using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Grid
    {
        public int x;
        public int y;
        public int flag;
        public Grid(int x, int y, int flag)
        {
            this.x = x;
            this.y = y;
            this.flag = flag;
        }
    }
}
