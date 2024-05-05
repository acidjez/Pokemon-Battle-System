namespace PokemonBattle
{
    public abstract class Item
    {
        private string _name;
        private string _description;

        public Item(string name, string desc) 
        {
            _name = name;
            _description = desc;
        }

        public abstract bool DoThing(Pokemon p);

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Desc
        { 
            get
            { 
                return _description; 
            } 
        }
    }

    
}
