using Padel;
using Xunit;

namespace PadelTest
{
    public class SetTest
    {
     /// <summary>
     /// Test if point added to list
     /// </summary>
        [Fact] 
        public void Set_List_Test()
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");
            var set = new Set(player1, player2);

            for (int i = 0; i < 3; i++)
            {
                set.Point(player1);
            }
            Assert.Single(set._games);
        }
        /// <summary>
        /// Test if index 0 is set and put in place 1
        /// </summary>
        [Fact]
        public void SetTest_List_Limit_True()
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");
            var set = new Set(player1, player2);

            for (int i = 0; i < 6; i++)
            {
                set.Point(player1);
            }
            Assert.True(set._games.Count== 2);
        }
       
    }
}