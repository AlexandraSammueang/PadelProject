using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Padel;

namespace PadelTest
{
    public class ScoreTest
    {
        /// <summary>
        /// Testing if increase score workes with diffrent values
        /// </summary>
        /// <param name="nrOfTimes"></param>
        /// <param name="expected"></param>
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
        /// <summary>
        /// Testing if Score could go negativ. Should not be able to reduce score, this is a bugg 
        /// </summary>
        [Fact]
        public void Score_Shold_Not_Allow_Negativ_Value() 
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2 ");
            var game = new Game(player1, player2);

            game.Point(player1);

            int negativValue = 1;
            player1.Score._Score = player1.Score._Score - negativValue;
            Assert.Equal(0,player1.Score._Score);
        }
    }
}