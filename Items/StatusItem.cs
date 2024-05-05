namespace PokemonBattle
{
    public class StatusItem : Item
    {
        public StatusItem(string name, string desc) :
            base(name, desc)
        {}


        public override bool DoThing(Pokemon poke)
        {
            if (!poke.IsAlive)
            {
                poke.State = new Normal(poke);
                return true;
            }
            return false;
        }
    }   
}

