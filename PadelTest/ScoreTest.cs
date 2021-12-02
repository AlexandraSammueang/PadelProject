using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Padel;

namespace PadelTest
{
    public class ScoreTest
    {
        [Theory]
        [InlineData(1, 1)] 
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void Score_Test(int nrOfTimes, int expected)
        {
            var score = new Score();

            for (int i = 0; i < nrOfTimes; i++)
            {
                score.Increase();
            }

            Assert.Equal(expected, score._Score);

        }
    }
}
