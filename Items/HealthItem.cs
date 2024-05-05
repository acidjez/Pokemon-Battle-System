namespace PokemonBattle
{
    public class HealthItem: Item
    {
        private int _heal;
        public HealthItem(string name, string desc, int heal) :
            base(name, desc)
        { 
            _heal = heal;   //how many hp to restore
        }


        public override bool DoThing(Pokemon p)
        {   
            if (p.IsAlive)
            {
                if ((p.HP + _heal) > p.MaxHP)
                {
                    p.HP = p.MaxHP;
                }
                else
                {
                    p.HP += _heal;
                }   
                return true;
            }        
            return false;
        }
    }
}
