namespace PokemonBattle
{
    public class GrassMove: Move
    {
        public GrassMove(string name, string desc, int damage, int crit) :
            base(name, desc, damage, crit)
        { }
        public override double Effectiveness(Pokemon enemy) ///calculate effectiveness and return multiplier
        {
            if (enemy.Type == TypeEnum.Water)
            {
                return 2.0;
            }

            if (enemy.Type == TypeEnum.Fire)
            {
                return 0.5;
            }

            if (enemy.Type == TypeEnum.Grass)
            {
                return 0.8;
            }
            return 1.0;
        }

        public override void StateChange(Pokemon enemy)  //if move happens to poison, change pokemon state
        {
            Random rnd = new Random();
            int chance = rnd.Next(1, 100);
            if (chance < 30 && enemy.State.StateEnum == StateEnum.Normal)
            {
                enemy.State = new Poisoned(enemy);
            }
        }
    }

    
}
