using Padel;
using Xunit;

namespace PadelTest
{
    public class MatchTest
    {
        [Fact]
        public void Match_Test_List_3Sets()
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");

            var match = new Match(3, player1, player2);

            for (int i = 0; i < 3; i++)
            {
                match.Point(player1);
            }

            Assert.Equal(3, match._sets.Count);

        }

        [Fact]
        public void Match_Test_List_ToManySets() // not allowed to get 4 sets
        {
            var player1 = new Player("Alexandra");
            var player2 = new Player("Fredrik");

            var match = new Match(3, player1, player2);

            for (int i = 0; i < 4; i++)
            {
                match.Point(player1);
            }

            Assert.Equal(3, match._sets.Count);

        }
        [Theory]
        [InlineData(3, 0, "Alexandra wins the match")]
        [InlineData(3, 1, "Fredrik wins the match")]
        [InlineData(0, 2, "Alexandra score is: 0 \n Fredrik score is: 2")]
        public void Match_ScoreString_Sholud_Return_Winner(int numberOfPoints, int gameCase, string expected)
        {
            Player player1 = new Player("Alexandra");
            Player player2 = new Player("Fredrik");
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
            if(gameCase == 2)
            {
                player1.Score._Score = 0;
                player2.Score._Score = 2;
            }

            var result = match.ScoreString();
            Assert.Equal(result, expected);


            //kolla listan går de att lägga till?
            //räknas set rätt?
            //om en match blir lika
            // om player 1 vinner förlorar player 2 match
            //om player1 förlorar vinner player2
            //kolla match point 
            //kolla match score

        }
        [Theory]
        [InlineData(3,2,0)]
        [InlineData(1,3,0)]
        [InlineData(0,0,0)]
        public void Score_Should_Return_Score(int _score1, int _score2, int expected)
        {
            Player player1 = new Player("");
            Player player2 = new Player("");
            Match match = new Match(3, player1, player2);

            player1.Score._Score = _score1;
            player2.Score._Score = _score2;
            var result = match.MatchScore();
            Assert.Equal(result._Score, expected);

        }
        [Fact]
        public void MatchPoint_Should_Increase_List()
        {
            Player player1 = new Player("");
            Player player2 = new Player("");
            Match match = new Match(3, player1, player2);
            player1.Score._Score = 3;
            match.Point(player1);
            Assert.Single(match._sets[0]._games);

        }
       
        
    }
}
