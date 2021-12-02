using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Padel;

namespace PadelTest
{
    public class SetTest
    {
        [Fact] //FEEEEL
        public void Set_List_Test()
        {


            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            var set = new Set(player1, player2);

            for (int i = 0; i < 3; i++)
            {
                set.Point(player1);

            }
            //Assert.Equal(3, set._games.Count); //förväntad 1 och inte 

            Assert.Single(set._games); //förväntad 

        }

        [Theory]
        [InlineData(3, 0, 40, 0)]
        [InlineData(0, 3, 0, 40)]
        [InlineData(1, 2, 15, 30)]
        public void Set_Point_Test(int player1score, int player2score, int expectedplayer1, int expectedplayer2)
        {
            int player1SetScore = 0;
            int player2SetScore = 0;

            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            var _set = new Set(player1, player2);



            for (int i = 0; i < player1score; i++)
            {
                _set.Point(player1);
                player1SetScore = _set._games[i].Score(player1)._Score;

            }


            for (int i = 0; i < player2score; i++)
            {
                _set.Point(player2);
                player2SetScore = _set._games[i].Score(player2)._Score;

            }

            Assert.Equal(expectedplayer1, player1SetScore);
            Assert.Equal(expectedplayer2, player2SetScore);
        }
    }
}