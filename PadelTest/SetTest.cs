using Padel;
using Xunit;

namespace PadelTest
{
    public class SetTest
    {
        [Fact] 
        public void Set_List_Test()
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            var set = new Set(player1, player2);

            for (int i = 0; i < 3; i++)
            {
                set.Point(player1);
            }
            Assert.Single(set._games);
        }
        [Fact]
        public void SetTest_List_Limit_True()
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");
            var set = new Set(player1, player2);

            for (int i = 0; i < 6; i++)
            {
                set.Point(player1);
            }
            Assert.True(set._games.Count== 2);
        }

        /*[Theory]
        [InlineData(3, 0, 3, 0)]
        [InlineData(0, 3, 0, 3)]
        [InlineData(1, 2, 1, 2)]
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
        }*/
    }
}