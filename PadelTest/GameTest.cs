using Padel;
using Xunit;

namespace PadelTest
{
    public class GameTest
    {
        /// <summary>
        /// Testing 2 cases by giving the winning point to player 1 vs player 2 and see correct player wins
        /// </summary>
        /// <param name="gameCase"></param>
        /// <param name="expectedScore"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(1, 5, "Player 1 wins")]
        [InlineData(2, 5, "Player 2 wins")]
        public void Game_test_Winner(int gameCase, int expectedScore, string expected)
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game = new Game(player1, player2);
            for (int i = 0; i < 5; i++)
            {
                if (gameCase == 1)
                {
                    game.Point(player1);
                }
                if (gameCase == 2)
                {
                    game.Point(player2);
                }
            }

            if (gameCase == 1) Assert.Equal(expectedScore, game.Score(player1)._Score);

            if (gameCase == 2) Assert.Equal(expectedScore, game.Score(player2)._Score);

            Assert.Equal(expected, game.ScoreString());
        }
        /// <summary>
        /// Testing if same score duce
        /// </summary>
        [Fact]
        public void Deuce_Test()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            player1.Score._Score = 0;
            player2.Score._Score = 0;

            var game = new Game(player1, player2);

            for (int i = 0; i < 4; i++)
            {
                game.Point(player1);
                game.Point(player2);
            }
            var result = game.ScoreString();

            Assert.Equal("Deuce", result);
        }

        /// <summary>
        /// Testing if player wins with 2 point after deuce
        /// </summary>

        [Fact]
        public void Winner_After_Deuce_player1()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game = new Game(player1, player2);
            for (int i = 0; i < 4; i++)
            {
                game.Point(player1);
                game.Point(player2);

            }
            game.Point(player1);
            game.Point(player1);

            var result = game.ScoreString();

            Assert.Equal("Player 1 wins", result);
        }
        [Fact]
        public void Winner_After_Deuce_player2()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game = new Game(player1, player2);
            for (int i = 0; i < 4; i++)
            {
                game.Point(player1);
                game.Point(player2);
            }
            game.Point(player2);
            game.Point(player2);
            var result = game.ScoreString();

            Assert.Equal("Player 2 wins", result);
        }

        /// <summary>
        /// Test if only 1 point after deuce no win
        /// </summary>
        [Fact]
        public void MatchPoint_After_Deuce_Only1Point()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game = new Game(player1, player2);
            for (int i = 0; i < 4; i++)
            {
                game.Point(player1);
                game.Point(player2);
            }
            game.Point(player2);
            var result = game.ScoreString();

            Assert.Equal("Match point", result);
        }
        
    }
}

