using Padel;
using Xunit;

namespace PadelTest
{
    public class MatchTest
    {
       /// <summary>
       /// Test if match is 3 set
       /// </summary>
        [Fact]
        public void Match_Test_List_3Sets() 
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");

            var match = new Match(3, player1, player2);

            for (int i = 0; i < 3; i++)
            {
                match.Point(player1);
            }

            Assert.Equal(3, match._sets.Count);

        }
        /// <summary>
        /// Test if to many sets, after 3 sets match end, even after giving player 1 four sets.
        /// </summary>
        [Fact]
        public void Match_Test_List_ToManySets() 
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2 ");

            var match = new Match(3, player1, player2);

            for (int i = 0; i < 4; i++)
            {
                match.Point(player1);
            }

            Assert.Equal(3, match._sets.Count);

        }
        /// <summary>
        /// Testing 3 cases with diffrent values to check if match score workes
        /// </summary>
        /// <param name="numberOfPoints"></param>
        /// <param name="gameCase"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(3, 0, "Player 1 wins the match")]
        [InlineData(3, 1, "Player 2 wins the match")]
        [InlineData(0, 2, "Player 1 score is: 0 \n Player 2 score is: 2")]
        public void Match_ScoreString_Sholud_Return_Winner_otherwise_score(int numberOfPoints, int gameCase, string expected)
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Match match = new Match(3, player1, player2);

            for (int i = 0; i < numberOfPoints; i++)
            {
                if (gameCase == 0)
                {
                    match.Point(player1);
                }
                else if (gameCase == 1)
                {
                    match.Point(player2);
                }

            }
            if (gameCase == 2)
            {
                player1.Score._Score = 0;
                player2.Score._Score = 2;
            }

            var result = match.ScoreString();
            Assert.Equal(result, expected);
        }
        /// <summary>
        /// Testing 3 cases with values to 
        /// </summary>
        /// <param name="_score1"></param>
        /// <param name="_score2"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(3, 2, 0)]
        [InlineData(1, 3, 0)]
        [InlineData(0, 0, 0)]
        public void Score_Should_Return_Score(int _score1, int _score2, int expected)
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Match match = new Match(3, player1, player2);

            player1.Score._Score = _score1;
            player2.Score._Score = _score2;
            var result = match.MatchScore();
            Assert.Equal(result._Score, expected);

        }
        /// <summary>
        /// Test match point , should not be able too add point after 3. This is a bugg!
        /// </summary>
        [Fact]
        public void MatchPoint_Test_Add_ToMany_Points() 
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Match match = new Match(3, player1, player2);
            player1.Score._Score = 3;
            match.Point(player1);
            Assert.Equal(3, player1.Score._Score);

        }
    }
}
