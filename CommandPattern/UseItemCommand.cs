namespace PokemonBattle
{
    public class UseItemCommand : ICommand
    {
        private Player _player;
        private Pokemon _pok;
        private Item _i;
        public UseItemCommand(Player player, Pokemon pok, Item i) 
        { 
            _player = player;
            _pok = pok;
            _i = i;           
        }

        public void Execute()
        {
            if (_player.UseItem(_pok, _i))
            {
               _player.Items.Remove(_i);
            }
        }
    }
}
