using System.Collections.Generic;

namespace Padel
{
    public class Match
    {
        public List<Set> _sets { get; } = new List<Set>();
        public Player _player1;
        public Player _player2;
        public Match(int numberOfSets, Player player1, Player player2)
        {
            _sets = new List<Set>(numberOfSets);
            for (int i = 0; i < numberOfSets; i++)
            {
                _sets.Add(new Set(player1, player2)); //Added 2 players
            }
            _player1 = player1;
            _player2 = player2;
        }

        public void Point(Player player)
        {
            if (player.Score._Score > 4)
            {
                var set = new Set(player, player);
                set.Point(player);
                _sets.Add(set);
            }
            else
            {
                _sets[^1].Point(player);

            }
            //_sets[0].Point(player); // bugg /not working
        }

        public Score MatchScore()
        {
            return new Score();
        }
        public string ScoreString() //Add this metod to count scores
        {
            if (_player1.Score._Score == 3)
            {
                return $"{_player1.Name} wins the match";
            }
            else if (_player2.Score._Score == 3)
            {
                return $"{_player2.Name} wins the match";
            }
            return $"{_player1.Name} score is: {_player1.Score._Score} \n {_player2.Name} score is: {_player2.Score._Score}";
        }
    }
}
