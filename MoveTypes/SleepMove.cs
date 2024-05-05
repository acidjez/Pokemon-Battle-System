namespace PokemonBattle
{
    public class SleepMove : Move
    {
        public SleepMove(string name, string desc, int damage, int crit) :
            base(name, desc, damage, crit)
        { }
   
        public override void StateChange(Pokemon enemy)
        {
            if (enemy.State.StateEnum != StateEnum.Asleep)
            {
                enemy.State = new Asleep(enemy);
            }
        }
    }
}
