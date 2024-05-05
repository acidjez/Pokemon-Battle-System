namespace PokemonBattle
{
    public class NormalMove: Move
    {
        public NormalMove(string name, string desc, int damage, int crit) :
            base(name, desc, damage, crit)
        { }
    }
}
