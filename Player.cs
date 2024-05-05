namespace PokemonBattle
{
    public class Player
    {
        private PokeList _pokeList;
        private List <Item> _items;
        public Player()
        { 
            _pokeList = new PokeList();
            _items = new List <Item>();
        }
 
        public bool  UseItem(Pokemon p, Item i)
        {
           return i.DoThing(p);
        }

        public PokeList PokeList { 
            get 
            { 
                return _pokeList;
            } 
        }

        public List<Item> Items 
        { 
            get 
            { 
                return _items; 
            } 
        }


    }
}
