
namespace PokemonBattle
{
    public class Asleep : State
    {
        private int _count;
        public Asleep(Pokemon p):
            base(p)
        {      
            _count = 4;
            StateEnum = StateEnum.Asleep;
            Name = "asleep";
        }

        public override void Fight(Pokemon enemy, Move move)
        {                     
            if (_count == 0 )
            {
                Pokemon.State = new Normal(Pokemon);
            }
            _count -= 1;
        }
    }
}
