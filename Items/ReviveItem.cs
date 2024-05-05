namespace PokemonBattle
{
    public class ReviveItem : Item
    {
        public ReviveItem(string name, string desc) :
            base(name, desc)
        {}

        //revives pokemon with 50% HP
        public override bool DoThing(Pokemon p)
        {
            if (!p.IsAlive)
            {
                p.IsAlive = true;
                p.HP = p.MaxHP / 2;
                return true;
            }
            return false;
        }
    }   

}

