namespace PokemonBattle
{
    public class Burned : State
    {
        private int _count;
        public Burned(Pokemon p) :
            base(p)
        {
            _count = 4;
            StateEnum = StateEnum.Burned;
            Name = "burned";
        }    
        public override int StateDamage()
        {
            int burnDamage = Pokemon.MaxHP / 7;
            if (Pokemon.Type == TypeEnum.Grass) 
            {
                burnDamage += burnDamage / 10;
            }

            if (_count == 0)
            {
                Pokemon.State = new Normal(Pokemon);
            }
            _count -= 1;

            return burnDamage;
        }
    }
}
