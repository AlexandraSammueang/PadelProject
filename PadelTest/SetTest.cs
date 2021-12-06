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
       
    }
}