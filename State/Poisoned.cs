
namespace PokemonBattle
{
    public class Poisoned : State
    {  
        private int _count;
      
        public Poisoned (Pokemon p) :
            base (p)
        {
            _count = 4;       
            StateEnum = StateEnum.Poisened;
            Name = "poisoned";
        }

        public override int StateDamage()
        {
            int poisonDamage = Pokemon.MaxHP / 9;
            if (Pokemon.Type==TypeEnum.Water)
            {
                poisonDamage += poisonDamage / 3;
            }
            if (_count == 0)
            {
                Pokemon.State = new Normal(Pokemon);
            }
            _count -= 1;

            return poisonDamage;
        }
    }
}
