using System;

namespace ProgrammingSkillsOne
{
    public class _001_CountOddsInRange
    {
        public int CountOddsInRange(int low, int high)
        {
            if (low > high)
            {
                throw new ArgumentException("low can not be higher than high");
            }

            if (low == high)
            {
                if (low % 2 != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            int odds_counter = 0;
            for (int i = low; i <= high; i ++)
            {
                if (i % 2 != 0)
                {
                    odds_counter++;
                }
            }
            return odds_counter;
        }
    }
}
