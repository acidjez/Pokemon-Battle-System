namespace PokemonBattle
{
    public class WaterMove: Move
    {
        public WaterMove(string name, string desc, int damage, int crit) :
            base(name, desc, damage, crit)
        { }
        public override double Effectiveness(Pokemon enemy)   ///calculate effectiveness and return multiplier
        {
            if (enemy.Type == TypeEnum.Water)
            {
                return 0.8;
            }

            if (enemy.Type == TypeEnum.Fire)
            {
                return 2.0;
            }

            if (enemy.Type == TypeEnum.Grass)
            {
                return 0.5;
            }
            return 1.0;
        }      
    }    
}
