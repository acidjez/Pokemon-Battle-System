namespace PokemonBattle
{
    public abstract class Move
    {
        private string _name;
        private string _description;
        private int _damage;
        private int _critChance;


        public Move(string name, string desc, int damage, int crit)
        {
            _name = name;
            _description = desc;
            _damage = damage;
            _critChance = crit;
        }


        public int CalcDamage(Pokemon player, Pokemon enemy)
        {
            double effectiveness = Effectiveness(enemy);

            double damage = (_damage * effectiveness) + (player.Attack - enemy.Defence);

            damage = damage * TypeDamage(player, enemy);


            if (IsCrit())                                             //increase damage if move is critical hit
            {
                damage += (damage / 10);
            }

            return (int)damage;
        }

        public virtual double Effectiveness(Pokemon enemy)                //overridden by child moves if they have changed effectiveness
        {
            return 1.0;
        }

        public virtual void StateChange(Pokemon enemy)
        {
            //do nothing
        }

        private static double TypeDamage(Pokemon player, Pokemon enemy)    //determines overall type damage and returns multiplier
        {

            if (player.Type == TypeEnum.Fire)
            {
                if (enemy.Type == TypeEnum.Grass)
                {
                    return 1.2;
                }

                if (enemy.Type == TypeEnum.Water)
                {
                    return 0.8;
                }
                return 1.0;
            }


            if (player.Type == TypeEnum.Water)          
            {
                if (enemy.Type == TypeEnum.Grass)
                {
                    return 0.8;
                }

                if (enemy.Type == TypeEnum.Fire)
                {
                    return 1.2;
                }

                return 1.0;
            }

            if (player.Type == TypeEnum.Grass)
            {
                if (enemy.Type == TypeEnum.Fire)
                {
                    return 0.8;
                }

                if (enemy.Type == TypeEnum.Water)
                {
                    return 1.2;
                }

                return 1.0;
            }
            return 1.0;
        }


        private bool IsCrit()                     //rolls the dice to determine if attack is a critical hit
        {
            Random rnd = new Random();
            int crit = rnd.Next(1, 100);

            if (crit < _critChance) 
            { 
                return true;
            }
            return false;
        }


        public string Name
        { 
            get 
            { 
                return _name; 
            } 
        }
    }
}
