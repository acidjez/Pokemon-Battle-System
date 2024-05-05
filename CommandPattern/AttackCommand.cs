
using System.Timers;

namespace PokemonBattle
{
    public class AttackCommand : ICommand
    {
        private Pokemon _player;
        private Pokemon _enemy;
        Move _move;
        private static System.Timers.Timer? _attackTimer;
        private int _wait;

        public AttackCommand(Pokemon player, Pokemon enemy, Move move, int wait) 
        {
            _player = player;
            _enemy = enemy;
            _move = move;
            _wait = wait;
        }

        public void Execute()
        {
            _attackTimer = new System.Timers.Timer(_wait);
            _attackTimer.Elapsed += Attack;
            _attackTimer.AutoReset = false;
            _attackTimer.Enabled = true;
        }

        private void Attack(Object? source, ElapsedEventArgs e)
        {
            if (_player.IsAlive)
            {
                _player.Fight(_enemy, _move);
            }

        }
    }
}
