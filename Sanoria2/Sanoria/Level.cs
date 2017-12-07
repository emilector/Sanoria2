using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanoria
{
    public class Level
    {
        public Level()
        {
            r = new Random();
            oper = "ERROR";
        }

        Random r;
        string oper;
        string output;
        public double m_result;

        public string nextLevel()
        {
            // Create random variables

            int x = r.Next(2, 99);
            int y = r.Next(2, 99);

            // Create random operator

            switch (r.Next(0, 3))
            {
                case 0: { oper = "+"; m_result = x + y; break; }
                case 1: { oper = "-"; m_result = x - y; break; }
                case 2: { oper = "*"; m_result = x * y; break; }
                case 3: { oper = "/"; m_result = x / y; break; }
            }

            output = x + " " + oper + " " + y + " =";
            return output;
        }
    }
}
