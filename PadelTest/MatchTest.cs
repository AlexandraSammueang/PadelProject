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
        /// Test should return the score in game  
        /// </summary>
        [Fact]
        public void Match_Score_Return_GameScore()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Game game = new Game(player1, player2);
            Match match = new Match(3, player1, player2);

            for (int i = 0; i < 4; i++)
            {
                game.Point(player1);
            }
            var result = match.MatchScore();
            Assert.True("Player 1 game score: 50 \n Player 2 game score: 0" == result.ToString());
        }
        /// <summary>
        /// Test should return the score in set 
        /// </summary>
        [Fact]
        public void Match_Score_Return_SetScore()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Set set = new Set(player1, player2);
            Match match = new Match(3, player1, player2);

            for (int i = 0; i < 3; i++)
            {
                set.Point(player1);
            }

            set.Point(player2);
            set.Point(player2);

            var result = match.MatchScore();
            Assert.True("Player 1 set score: 3 \n Player 2 set score: 2" == result.ToString());
        }
        /// <summary>
        /// Test should return the score in match
        /// </summary>
        [Fact]
        public void Match_Score_Return_MatchScore()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Match match = new Match(3, player1, player2);

            for (int i = 0; i < 3; i++)
            {
                match.Point(player1);
            }
            match.Point(player2);
            match.Point(player2);

            var result = match.MatchScore();
            Assert.True("Player 1 match score: 3 \n Player 2 game score: 2" == result.ToString());
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
