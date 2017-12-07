using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sanoria
{
    public class Logic
    {
        public Logic()
        {
        }

        int m_CurrentLevel = 0;
        List<Level> m_levels = new List<Level>();

        // Erstes Level übergeben

        public string getFirstLevel()
        {
            return nextLevel();  
        }

        // Generate new Level + count

        string nextLevel()
        {
            m_CurrentLevel++;
            Level level = new Level();
            string newLevel = level.nextLevel();
            m_levels.Add(level);

            return newLevel;
        }

        // Comfirm correct result

        public string confirm(string result)
        {
            string newLevel = "WrongAnswer";

            if (Convert.ToDouble(result) == m_levels[m_CurrentLevel - 1].m_result)
            {
                newLevel = nextLevel();
                return newLevel;
            }

            return newLevel;
        }
    }
}
