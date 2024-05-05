
namespace PokemonBattle
{
    public abstract class State
    {
        private StateEnum _state;
        private Pokemon _p;
        private string _name;

        public State(Pokemon p)
        {
            _p = p;
            _name = "";
        }
        public virtual void Fight(Pokemon enemy, Move move)
        {
            int damage = move.CalcDamage(_p, enemy);

            move.StateChange(enemy);              //change state of enemy player if conditions in Statechange function met 

            if (_p.HP - StateDamage() > 0)      
            {
                _p.HP -= StateDamage();         //inflict state damage onto pokemon
            }
            else
            {
                _p.HP = 0;                     //set pokemon HP to 0 if state damage overshoots HP
            }

            if ((enemy.HP - damage) < 0)
            {
                enemy.HP = 0;
            }
            else
            {
                enemy.HP = (int)(enemy.HP - damage);   //inflict move damage on opposing pokemon
            } 
        }

        public virtual int StateDamage()        //overridden by child states if they inflict damage
        {
            return 0;
        }

        public StateEnum StateEnum
        { 
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public Pokemon Pokemon 
        { 
            get 
            { 
                return _p; 
            } 
        }

        public string Name
        {
            get 
            { 
                return _name; 
            }
            set 
            {
                _name = value; 
            }
        }
    }    
}
