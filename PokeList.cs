namespace PokemonBattle
{
    public class PokeList
    {
        private List<Pokemon> _pokemons;
        public PokeList()
        {
            _pokemons = new List<Pokemon>();
        }
        public PokeList(List<Pokemon> pokemons)
        {
            _pokemons = pokemons;
        }

        public bool AddPokemon(Pokemon pokemon)
        {
            if (_pokemons.Count <= 5)
            {
                _pokemons.Add(pokemon);
                return true;
            }
            return false;
        }

        public void RemovePokemon(int num)
        {
            _pokemons.RemoveAt(num);
        }

     
        public List<Pokemon> List
        {
            get 
            { 
                return _pokemons;
            }
        }

        public Pokemon GetNext() 
        { 
            foreach (Pokemon p in _pokemons)
            { 
                if (p.IsAlive) 
                { 
                    return p;
                }               
            }
            return null;
        }

    }
}
