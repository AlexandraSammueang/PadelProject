using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Padel;

namespace PadelTest
{
    public class PlayerTest
    {
        /// <summary>
        /// Testing Player Name is not null
        /// </summary>
        [Fact]
        public void PlayerTest_Check_Name_NotNull()
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");

            Assert.NotNull(player1.Name);
            Assert.NotNull(player2.Name); 


        }
        /// <summary>
        /// Testing  Player Name not Empty
        /// </summary>
        [Fact]
        public void PlayerTest_Check_Name_Empty()
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2 ");

            Assert.NotEmpty(player1.Name); 
            Assert.NotEmpty(player2.Name); 

        }
        /// <summary>
        /// Test adding point to player, with diffrent values 
        /// </summary>
        /// <param name="nrOfTimes"></param>
        /// <param name="expected"></param>

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void Player_Point_Score(int nrOfTimes, int expected)
        {
            var player1 = new Player("Player 1");

            for (int i = 0; i < nrOfTimes; i++)
            {
                player1.Point();
            }

            Assert.Equal(expected, player1.Score._Score);

        }
    }
}
